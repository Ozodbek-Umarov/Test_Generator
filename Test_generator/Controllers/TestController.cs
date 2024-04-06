using Application.DTOs.TestDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_generator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController(ITestService testService) 
    : ControllerBase
{
    private readonly ITestService _testService = testService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddTestDto dto)
    {
        await _testService.CreateAsync(dto);
        return Ok();
    }


    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await  _testService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _testService.GetByIdAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _testService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] TestDto dto)
    {
        await _testService.UpdateAsync(dto);
        return Ok();
    }
}
