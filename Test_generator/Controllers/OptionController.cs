using Application.DTOs.OptionDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_generator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OptionController(IOptionService optionService) : ControllerBase
{
    private readonly IOptionService _optionService = optionService;

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] AddOptionDto dto)
    {
        await _optionService.CreateAsync(dto);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _optionService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        return Ok(await _optionService.GetByIdAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _optionService.DeleteAsync(id);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] OptionDto dto)
    {
        await _optionService.UpdateAsync(dto);
        return Ok();
    }
}

