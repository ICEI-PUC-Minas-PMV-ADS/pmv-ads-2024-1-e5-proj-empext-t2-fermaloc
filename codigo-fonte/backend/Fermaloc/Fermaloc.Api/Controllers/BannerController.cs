using Fermaloc.Application;
using Microsoft.AspNetCore.Mvc;
namespace Fermaloc.Api;


[ApiController]
[Route("fermaloc/v1/banner")]
public class BannerController : ControllerBase
{
    protected IBannerService _bannerService;

    // [HttpPost]
    // public async Task<IActionResult> CreateAdministrator ([FromBody] CreateAdministratorDto administratorDto){
    //     var administradorDto = await _administratorService.CreateAdministratorAsync(administratorDto);
    //     return CreatedAtAction(nameof(GetAdministrator), new { id = administradorDto.Id }, administradorDto);
    // }

    // [HttpGet("{id}")]
    // public async Task<IActionResult> GetAdministrator(Guid id){
    //     var administradorDto = await _administratorService.GetAdministratorAsync(id);
    //     return Ok(administradorDto);
    // }
    // [HttpPut("id")]
    // public async Task<IActionResult> UpdateAdministrator (Guid id, [FromBody] UpdateAdministratorDto administratorDto){
    //     await _administratorService.UpdateAdministratorAsync(id, administratorDto);
    //     return NoContent();
    // }
    // [HttpDelete("id")]
    // public async Task<IActionResult> DeleteAdministrator (Guid id){
    //     await _administratorService.DeleteAdministratorAsync(id);
    //     return NoContent();
    // }


}
