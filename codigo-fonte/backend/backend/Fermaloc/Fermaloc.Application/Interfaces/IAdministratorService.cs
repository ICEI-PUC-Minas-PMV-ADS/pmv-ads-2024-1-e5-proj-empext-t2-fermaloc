using Fermaloc.Domain;

namespace Fermaloc.Application;

public interface IAdministratorService
{
    Task<ReadAdministratorDto> CreateAdministratorAsync (CreateAdministratorDto administratorDto);
    Task<ReadAdministratorDto> GetAdministratorByIdAsync (Guid id);
    Task<ReadAdministratorDto> UpdateAdministratorAsync (Guid id, UpdateAdministratorDto administratorDto);
    Task<ReadAdministratorDto>  DeleteAdministratorAsync (Guid id);
    Task<LoginResponseDto> Login (LoginRequestDto loginRequestDto);
    Task ResetPassword (string email);
}
