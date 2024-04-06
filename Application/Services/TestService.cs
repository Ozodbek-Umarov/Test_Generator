using Application.Common.Exceptions;
using Application.Common.Validators;
using Application.DTOs.OptionDtos;
using Application.DTOs.TestDtos;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using FluentValidation;
using System.Net;

namespace Application.Services;

public class TestService(IUnitOfWork unitOfWork,
                         IValidator<Test> validator)
    : ITestService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Test> _validator = validator;

    public async Task CreateAsync(AddTestDto dto)
    {
        var test = await _unitOfWork.Test.GetByQuestionAsync(dto.Question);
        if (test != null)
            throw new StatusCodeExeption(HttpStatusCode.AlreadyReported, "Savol oldin foydalanilgan");
        await _unitOfWork.Test.CreateAsync((Test)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var test = await _unitOfWork.Test.GetByIdAsync(id);
        if (test is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Test topilmadi");
        await _unitOfWork.Test.DeleteAsync(test);
    }

    public async Task<List<TestDto>> GetAllAsync()
    {
        var options = await _unitOfWork.Option.GetAllAsync();
        var tests = await _unitOfWork.Test.GetAllAsync();

        var random = new Random();

        tests = tests.OrderBy(t => random.Next()).ToList();

        var testDtos = new List<TestDto>();
        foreach (var test in tests)
        {
            var relatedOptions = options.Where(o => o.TestId == test.Id).ToList();

            relatedOptions = relatedOptions.OrderBy(o => random.Next()).ToList();

            var testDto = new TestDto
            {
                Id = test.Id,
                Question = test.Question,
                Options = relatedOptions.Select(o => new OptionDto
                {
                    Id = o.Id,
                    Variant = o.Variant,
                    TestId = o.TestId
                }).ToList()
            };
            testDtos.Add(testDto);
        }
        return testDtos;
    }


    public async Task<TestDto> GetByIdAsync(int id)
    {
        var test = await _unitOfWork.Test.GetByIdAsync(id);
        if (test is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Test mavjud emas");

        return (TestDto)test;
    }

    public async Task UpdateAsync(TestDto dto)
    {
        var test = await _unitOfWork.Test.GetByIdAsync(dto.Id);
        if (test is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Test topilmadi");

        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidatorException(result.GetErrorMessages());

        await _unitOfWork.Test.UpdateAsync((Test)dto);
    }
}
