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

public class OptionService(IUnitOfWork unitOfWork,
                           IValidator<Option> validator)
    : IOptionService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IValidator<Option> _validator = validator;

    public async Task CreateAsync(AddOptionDto dto)
    {
        var result = await _validator.ValidateAsync(dto);
        if (!result.IsValid)
            throw new ValidationException(result.GetErrorMessages());
        await _unitOfWork.Option.CreateAsync((Option)dto);
    }

    public async Task DeleteAsync(int id)
    {
        var option = await _unitOfWork.Option.GetByIdAsync(id);
        if (option is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Test mavjud emas");
        await _unitOfWork.Option.DeleteAsync(option);
    }

    public async Task<List<OptionDto>> GetAllAsync()
    {
        var options = await _unitOfWork.Option.GetAllAsync();
        return options.Select(item => (OptionDto)item).ToList();
    }

    public async Task<OptionDto> GetByIdAsync(int id)
    {
        var option = await _unitOfWork.Option.GetByIdAsync(id);
        if (option is null)
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Test topilmadi");
        var test = await _unitOfWork.Test.GetByIdAsync(option.TestId);
        var entity = (Option)option;

        entity.Test = new Test()
        {
            Id = test.Id,
            Question = test.Question,
        };
        return entity;
    }

    public async Task UpdateAsync(OptionDto dto)
    {
        var option = await _unitOfWork.Option.GetByIdAsync(dto.Id);
        if (option == null)
        {
            throw new StatusCodeExeption(HttpStatusCode.NotFound, "Option mavjud emas");
        }

        option.Variant = dto.Variant;
        option.TestId = dto.TestId;

        await _unitOfWork.Option.UpdateAsync(option);
    }
}
