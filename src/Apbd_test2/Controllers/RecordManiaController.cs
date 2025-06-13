using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecordsController : ControllerBase
{
    private readonly IRecordManiaService _recordService;

    public RecordsController(IRecordManiaService recordService)
    {
        _recordService = recordService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecords(
        [FromQuery] DateTime? createdAfter,
        [FromQuery] int? programmingLanguageId,
        [FromQuery] int? taskId)
    {
        var records = await _recordService.GetRecordsAsync(createdAfter, programmingLanguageId, taskId);
        return Ok(records);
    }

    [HttpPost]
    public async Task<IActionResult> AddRecord([FromBody] CreateRecordDto dto)
    {
        await _recordService.AddRecordAsync(dto);
        return CreatedAtAction(nameof(GetRecords), null);
    }
}