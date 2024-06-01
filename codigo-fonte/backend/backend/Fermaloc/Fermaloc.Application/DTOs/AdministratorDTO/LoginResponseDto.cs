using Fermaloc.Domain;

namespace Fermaloc.Application;

public class LoginResponseDto
{
    public LoginResponseDto(string token)
    {
        Token = token;
    }
    public string Token { get; set; }

    
}
