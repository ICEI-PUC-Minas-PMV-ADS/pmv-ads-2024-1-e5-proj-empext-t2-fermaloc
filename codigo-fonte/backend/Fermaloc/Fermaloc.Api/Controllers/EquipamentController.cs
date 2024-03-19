using Fermaloc.Application;
using Microsoft.AspNetCore.Mvc;
namespace Fermaloc.Api;

[ApiController]
[Route("fermaloc/v1/equipamento")]
public class EquipamentController : ControllerBase
{
    private readonly IEquipamentService _equipamentService;

    public EquipamentController(IEquipamentService equipamentService)
    {
        _equipamentService = equipamentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEquipament ([FromForm] CreateEquipamentDto equipamentDto, IFormFile image){
        byte[]? imageBytes = null;
        using (var memoryStream = new MemoryStream())
        {
            await image.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }
        var equipamentCreated = await _equipamentService.CreateEquipamentAsync(equipamentDto, imageBytes);
        return CreatedAtAction(nameof(GetEquipamentById), new { id = equipamentCreated.Id }, equipamentCreated);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEquipamentById(Guid id){
        var equipamentDto = await _equipamentService.GetEquipamentByIdAsync(id);
        return Ok(equipamentDto);
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAllEquipaments([FromQuery] int skip){
        var equipamentsDto = await _equipamentService.GetAllEquipamentsAsync();
        return Ok(equipamentsDto);
    }
    
    [HttpGet("status")]
    public async Task<IActionResult> GetEquipamentsByStatus([FromQuery] int skip, bool status){
        var equipamentsDto = await _equipamentService.GetEquipamentsByStatusAsync(status);
        return Ok(equipamentsDto);
    }
    
    [HttpGet("statusandcategory")]
    public async Task<IActionResult> GetEquipamentsByStatusAndCategory([FromQuery] int skip, bool status, Guid categoryId){
        var equipamentsDto = await _equipamentService.GetEquipamentsByStatusAndCategoryAsync(status, categoryId);
        return Ok(equipamentsDto);
    }
    
    [HttpGet("search")]
    public async Task<IActionResult> GetEquipamentsSearchNameEquipament([FromQuery] string nameEquipament){
        var equipamentsDto = await _equipamentService.GetEquipamentsSearchNameEquipamentAsync(nameEquipament);
        return Ok(equipamentsDto);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEquipament (Guid id, [FromForm] UpdateEquipamentDto equipamentDto, IFormFile? image){
        if(image == null){
            await _equipamentService.UpdateEquipamentAsync(id, equipamentDto, null);
            return NoContent();
        }
        byte[]? imageBytes = null;
        using (var memoryStream = new MemoryStream())
        {
            await image.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }
        await _equipamentService.UpdateEquipamentAsync(id, equipamentDto, imageBytes);
        return NoContent();
    }
    
    [HttpPut("{id}/updateequipamentstatus")]
    public async Task<IActionResult> UpdateEquipamentStatus (Guid id){
        await _equipamentService.UpdateEquipamentStatusAsync(id);
        return NoContent();
    }
    
    [HttpPut("{id}/addclickcount")]
    public async Task<IActionResult> AddClickCountEquipament (Guid id){
        await _equipamentService.AddClickCountEquipamentAsync(id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipament (Guid id){
        await _equipamentService.DeleteEquipamentAsync(id);
        return NoContent();
    }
}
