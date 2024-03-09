using Fermaloc.Application;
using Microsoft.AspNetCore.Mvc;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
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
    public async Task<IActionResult> GetAllEquipaments(){
        var equipamentsDto = await _equipamentService.GetAllEquipamentsAsync();
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

    [HttpPatch("{id}/updateequipamentstatus")]
    public async Task<IActionResult> UpdateEquipamentStatus (Guid id){
        throw new NotImplementedException();
    }

    [HttpPatch("{id}/addclickcount")]
    public Task<IActionResult> AddClickCountEquipament (Guid id){
        throw new NotImplementedException();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipament (Guid id){
        await _equipamentService.DeleteEquipamentAsync(id);
        return NoContent();
    }
}
