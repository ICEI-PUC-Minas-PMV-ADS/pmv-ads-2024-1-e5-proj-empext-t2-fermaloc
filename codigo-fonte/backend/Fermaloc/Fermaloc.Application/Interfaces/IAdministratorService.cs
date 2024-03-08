using Fermaloc.Domain;

namespace Fermaloc.Application;

public interface IAdministratorService
{
    Task<ReadAdministratorDto> CreateAdministratorAsync (CreateAdministratorDto administratorDto);
    Task<ReadAdministratorDto> GetAdministratorAsync (Guid id);
    Task<ReadAdministratorDto> UpdateAdministratorAsync (Guid id, UpdateAdministratorDto administratorDto);
    Task<ReadAdministratorDto>  DeleteAdministratorAsync (Guid id);
}
