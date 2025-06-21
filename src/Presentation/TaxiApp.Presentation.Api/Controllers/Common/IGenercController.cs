using Microsoft.AspNetCore.Mvc;
using TaxiApp.Core.Application.Interfaces.Common;
using TaxiApp.Core.Domain.Common;

namespace TaxiApp.Presentation.Api.Controllers.Common;

[ApiController]
[Route("api/[controller]")]
public class GenericController<TDto, TEntity> : ControllerBase
    where TDto : class
    where TEntity : class
{
    private readonly IGenericService<TDto, TEntity> _service;

    public GenericController(IGenericService<TDto, TEntity> service)
    {
        _service = service;
    }

    [HttpGet]
    public virtual async Task<IActionResult> Get()
    {
        var result = await _service.GetAllAsync();
        if (!result.IsSuccess) return BadRequest(result);
        if (result.Data.Count == 0) return NoContent();
        return Ok(result);
    }

    [HttpGet("with")]
    public virtual async Task<IActionResult> GetWithIncludes([FromQuery] List<string> properties)
    {
        var result = await _service.GetAllIncludeAsync(properties);
        if (!result.IsSuccess) return BadRequest(result);
        if (result.Data.Count == 0) return NoContent();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetByIdAsync(id);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Post([FromBody] TDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _service.AddAsync(dto);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("batch")]
    public virtual async Task<IActionResult> PostBatch([FromBody] ICollection<TDto> dtos)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _service.AddRangeAsync(dtos);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Put(int id, [FromBody] TDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var idProp = typeof(TDto).GetProperty("Id");
        if (idProp != null && !id.Equals(idProp.GetValue(dto)))
            return BadRequest("ID mismatch between route and body.");

        var result = await _service.UpdateAsync(dto);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var result = await _service.RemoveAsync(id);
        if (!result.IsSuccess) return BadRequest(result);
        return Ok(result);
    }
}