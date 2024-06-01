namespace Fermaloc.Domain;

public interface IAdministratorRepository
{
    Task<Administrator> CreateAdministratorAsync (Administrator administrator);
    Task<Administrator> GetAdministratorByIdAsync (Guid id);
    Task<Administrator> GetAdministratorByEmailAsync(string email);
    Task<Administrator> UpdateAdministratorAsync (Administrator administrator);
    Task<Administrator>  DeleteAdministratorAsync (Administrator administrator);
}
