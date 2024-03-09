using Fermaloc.Application;
using Microsoft.AspNetCore.Mvc;
namespace Fermaloc.Api;


[ApiController]
[Route("fermaloc/v1/banner")]
public class BannerController : ControllerBase
{
    private readonly IBannerService _bannerService;

    public BannerController(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    [HttpPost]
    public async Task<IActionResult> Create ([FromForm] CreateBannerDto bannerDto, IFormFile image){
        byte[]? imageBytes = null;
        using (var memoryStream = new MemoryStream())
        {
            await image.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }

        var administradorDto = await _bannerService.CreateBannerAsync(bannerDto, imageBytes);
        return CreatedAtAction(nameof(GetAdministrator), new { id = administradorDto.Id }, administradorDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAdministrator(Guid id){
        var administradorDto = await _bannerService.GetBannerByIdAsync(id);
        return Ok(administradorDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAdministrator (Guid id,IFormFile image){
        byte[]? imageBytes = null;
        using (var memoryStream = new MemoryStream())
        {
            await image.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }

        await _bannerService.UpdateBannerAsync(id, imageBytes);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAdministrator (Guid id){
        await _bannerService.DeleteBannerAsync(id);
        return NoContent();
    }
}
