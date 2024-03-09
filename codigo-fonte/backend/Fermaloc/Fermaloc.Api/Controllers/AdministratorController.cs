using Fermaloc.Application;
using Microsoft.AspNetCore.Mvc;


namespace Fermaloc.Api;

[ApiController]
[Route("fermaloc/v1/administrador")]
public class AdministratorController : ControllerBase
{
    private readonly IAdministratorService _administratorService;

    public AdministratorController(IAdministratorService administratorService)
    {
        _administratorService = administratorService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdministrator ([FromBody] CreateAdministratorDto administratorDto){
        var administratorCreated = await _administratorService.CreateAdministratorAsync(administratorDto);
        return CreatedAtAction(nameof(GetAdministrator), new { id = administratorCreated.Id }, administratorCreated);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdministrator(Guid id){
        var administratorDto = await _administratorService.GetAdministratorAsync(id);
        return Ok(administratorDto);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdministrator (Guid id, [FromBody] UpdateAdministratorDto administratorDto){
        await _administratorService.UpdateAdministratorAsync(id, administratorDto);
        return NoContent();
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdministrator (Guid id){
        await _administratorService.DeleteAdministratorAsync(id);
        return NoContent();
    }
}
