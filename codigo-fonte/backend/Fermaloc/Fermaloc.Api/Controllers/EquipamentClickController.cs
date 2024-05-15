using Fermaloc.Application;
using Fermaloc.Application.DTOs.EquipamentClicksDTO;
using Microsoft.AspNetCore.Mvc;

namespace Fermaloc.Api;

[ApiController]
[Route("fermaloc/v1/click")]
public class EquipamentClickController : ControllerBase
{
    private readonly IEquipamentClicksService _equipamentClicksService;

    public EquipamentClickController(IEquipamentClicksService equipamentClicksService)
    {
        _equipamentClicksService = equipamentClicksService;
    }

    [HttpPost]
    public async Task<IActionResult> AddClick([FromBody] EquipamentClicksDto equipamentClicksDto )
    {
        await _equipamentClicksService.AddClickAsync(equipamentClicksDto);
        return Created(string.Empty, null);
    }
}