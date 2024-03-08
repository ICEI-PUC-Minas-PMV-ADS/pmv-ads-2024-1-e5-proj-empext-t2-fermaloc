namespace Fermaloc.Domain;

public interface IAdministratorRepository
{
    Task<Administrator> CreateAdministratorAsync (Administrator administrator);
    Task<Administrator> GetAdministratorAsync (Guid id);
    Task<Administrator> UpdateAdministratorAsync (Administrator administrator);
    Task<Administrator>  DeleteAdministratorAsync (Guid id);
}
