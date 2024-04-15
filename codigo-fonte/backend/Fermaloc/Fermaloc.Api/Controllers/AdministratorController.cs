using Fermaloc.Application;
using Microsoft.AspNetCore.Authorization;
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
    
    [HttpPost("login")]
    public async Task<IActionResult> Login ([FromBody] LoginRequestDto loginRequestDto){
        var loginResponseDto = await _administratorService.Login(loginRequestDto);
        return Ok(loginResponseDto);
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetAdministrator(Guid id){
        var administratorDto = await _administratorService.GetAdministratorByIdAsync(id);
        return Ok(administratorDto);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateAdministrator (Guid id, [FromBody] UpdateAdministratorDto administratorDto){
        await _administratorService.UpdateAdministratorAsync(id, administratorDto);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteAdministrator (Guid id){
        await _administratorService.DeleteAdministratorAsync(id);
        return NoContent();
    }


    [HttpPost("resetpassword")]
    public async Task<IActionResult> ResetAdministratorPassword ([FromBody] ResetPasswordDto resetPasswordDto){
        await _administratorService.ResetPassword(resetPasswordDto.Email);
        return NoContent();
    }
}
