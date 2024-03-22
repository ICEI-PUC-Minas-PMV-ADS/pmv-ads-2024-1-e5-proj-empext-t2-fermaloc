using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class AdministratorService : IAdministratorService
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IAuthenticateService _authenticateService;
    private readonly IMapper _mapper;

    public AdministratorService(IAdministratorRepository administratorRepository, IMapper mapper, IAuthenticateService authenticateService)
    {
        _administratorRepository = administratorRepository;
        _mapper = mapper;
        _authenticateService = authenticateService;
    }

    public async Task<ReadAdministratorDto> CreateAdministratorAsync(CreateAdministratorDto administratorDto)
    {
        administratorDto.Password = _authenticateService.HashPassword(administratorDto.Password);
        var administrator = _mapper.Map<Administrator>(administratorDto);
        var administratorCreated = await _administratorRepository.CreateAdministratorAsync(administrator);
        return _mapper.Map<ReadAdministratorDto>(administratorCreated);
    }

    public async Task<ReadAdministratorDto> GetAdministratorByIdAsync(Guid id)
    {
        var administrator = await _administratorRepository.GetAdministratorByIdAsync(id);
        if(administrator == null){
            throw new NotFoundException("Administrador não encontrado");
        }
        var administratorDto = _mapper.Map<ReadAdministratorDto>(administrator);
        return administratorDto;
    }

    public async Task<ReadAdministratorDto> UpdateAdministratorAsync(Guid id, UpdateAdministratorDto administratorDto)
    {
        var administrator = await _administratorRepository.GetAdministratorByIdAsync(id);
        if(administrator == null){
            throw new NotFoundException("Administrador não encontrado");
        }
        _mapper.Map(administratorDto, administrator);
        var administratorUpdated = await _administratorRepository.UpdateAdministratorAsync(administrator);
        return _mapper.Map<ReadAdministratorDto>(administratorUpdated);
    }

    public async Task<ReadAdministratorDto> DeleteAdministratorAsync(Guid id)
    {
        var administrator = await _administratorRepository.GetAdministratorByIdAsync(id);
        if(administrator == null){
            throw new NotFoundException("Administrador não encontrado");
        }
        var administratorDeleted = await _administratorRepository.DeleteAdministratorAsync(administrator);
        return _mapper.Map<ReadAdministratorDto>(administratorDeleted);
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        var administratorExists = await _authenticateService.AdministratorExists(loginRequestDto.Email);
        if(!administratorExists){
            throw new LoginException("Dados de login invalidos");
        }
        var authenticated = await _authenticateService.AuthenticateAsync(loginRequestDto.Email, loginRequestDto.Password);
        if(authenticated){
            var administrator = await _administratorRepository.GetAdministratorByEmailAsync(loginRequestDto.Email);
            var token = _authenticateService.GenerateToken(administrator);
            LoginResponseDto loginResponseDto = new(token);
            return loginResponseDto;
        }
        throw new LoginException("Dados de login invalidos");
        
    }
}
