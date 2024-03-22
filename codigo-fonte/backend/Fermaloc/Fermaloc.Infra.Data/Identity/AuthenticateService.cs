using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Fermaloc.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Fermaloc.Infra.Data;

public class AuthenticateService : IAuthenticateService
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        
        var administrator = await _context.Administrators.FirstOrDefaultAsync(a => a.Email == email);
        var passwordIsCorrect = VerifyPassword(password, administrator.Password);
        if(passwordIsCorrect){
            return true;
        }
        return false;
    }

    public async Task<bool> AdministratorExists(string email){
        var user = await _context.Administrators.FirstOrDefaultAsync(a => a.Email == email);
        if(user == null){
            return false;
        }
        return true;
    }

    public string GenerateToken(Administrator administrator)
    {
            var key = Encoding.ASCII.GetBytes(_configuration["jwt:secretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, administrator.Name),
                    new Claim(ClaimTypes.Role, administrator.Role),
                    new Claim(ClaimTypes.Sid, administrator.CNPJ)
                }),
                Expires = DateTime.UtcNow.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, 12);
    }
}
