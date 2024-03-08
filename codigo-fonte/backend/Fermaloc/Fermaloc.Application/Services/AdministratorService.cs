
using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class AdministratorService : IAdministratorService
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IMapper _mapper;

    public AdministratorService(IAdministratorRepository administratorRepository, IMapper mapper)
    {
        _administratorRepository = administratorRepository;
        _mapper = mapper;
    }

    public async Task<ReadAdministratorDto> CreateAdministratorAsync(CreateAdministratorDto administratorDto)
    {
        var administrator = _mapper.Map<Administrator>(administratorDto);
        administrator.Role = "admin";
        var administratorCreated = await _administratorRepository.CreateAdministratorAsync(administrator);
        return _mapper.Map<ReadAdministratorDto>(administratorCreated);
    }

    public async Task<ReadAdministratorDto> GetAdministratorAsync(Guid id)
    {
        var administrator = await _administratorRepository.GetAdministratorAsync(id);
        var administratorDto = _mapper.Map<ReadAdministratorDto>(administrator);
        return administratorDto;
    }

    public async Task<ReadAdministratorDto> UpdateAdministratorAsync(Guid id, UpdateAdministratorDto administratorDto)
    {
        var administrator = await _administratorRepository.GetAdministratorAsync(id);
        _mapper.Map(administratorDto, administrator);
        var administratorUpdated = await _administratorRepository.UpdateAdministratorAsync(administrator);
        return _mapper.Map<ReadAdministratorDto>(administratorUpdated);
    }

    public async Task<ReadAdministratorDto> DeleteAdministratorAsync(Guid id)
    {
        var administrator = await _administratorRepository.DeleteAdministratorAsync(id);
        return _mapper.Map<ReadAdministratorDto>(administrator);
    }
}
