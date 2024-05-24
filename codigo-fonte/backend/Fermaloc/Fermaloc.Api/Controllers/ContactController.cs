using Fermaloc.Application;
using Fermaloc.Application.DTOs.ContactDTO;
using Microsoft.AspNetCore.Mvc;

namespace Fermaloc.Api;

[ApiController]
[Route("fermaloc/v1/contact")]
public class ContactController : ControllerBase
{
    private readonly IEmailService _emailService;

    public ContactController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Contact([FromBody] ContactDto contactDto)
    {
        await _emailService.SendContactMail(contactDto.Message, contactDto.Email, contactDto.PhoneNumber1, contactDto.PhoneNumber2);
        return Ok();
    }
}