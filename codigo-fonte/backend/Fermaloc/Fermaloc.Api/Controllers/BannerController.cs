using Fermaloc.Application;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public async Task<IActionResult> CreateBanner ([FromForm] CreateBannerDto bannerDto, IFormFile image){
        byte[]? imageBytes = null;
        using (var memoryStream = new MemoryStream())
        {
            await image.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }

        var administradorDto = await _bannerService.CreateBannerAsync(bannerDto, imageBytes);
        return CreatedAtAction(nameof(GetBanner), new { id = administradorDto.Id }, administradorDto);
    }

    [HttpGet()]
    public async Task<IActionResult> GetBanner(){
        var administradorDto = await _bannerService.GetBannerAsync();
        return Ok(administradorDto);
    }

    [HttpPut()]
    [Authorize]
    public async Task<IActionResult> UpdateBanner (IFormFile image){
        byte[]? imageBytes = null;
        using (var memoryStream = new MemoryStream())
        {
            await image.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }

        await _bannerService.UpdateBannerAsync(imageBytes);
        return NoContent();
    }

    [HttpDelete()]
    [Authorize]
    public async Task<IActionResult> DeleteBanner (){
        await _bannerService.DeleteBannerAsync();
        return NoContent();
    }
}
