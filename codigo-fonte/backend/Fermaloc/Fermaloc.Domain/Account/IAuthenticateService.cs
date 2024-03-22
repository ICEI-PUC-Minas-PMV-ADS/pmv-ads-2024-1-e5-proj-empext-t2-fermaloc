namespace Fermaloc.Domain;

public interface IAuthenticateService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> AdministratorExists(string email);
    string GenerateToken(Administrator administrator);
    bool VerifyPassword(string password, string hashedPassword);
    string HashPassword(string password);
}
