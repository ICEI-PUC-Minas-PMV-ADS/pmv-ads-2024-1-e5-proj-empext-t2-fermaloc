using System.Text;
using AutoMapper;
using Fermaloc.Domain;
using Fermaloc.Domain.Validations;

namespace Fermaloc.Application;

public class AdministratorService : IAdministratorService
{
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IAuthenticateService _authenticateService;
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public AdministratorService(IAdministratorRepository administratorRepository, IMapper mapper, IAuthenticateService authenticateService, IEmailService emailService)
    {
        _administratorRepository = administratorRepository;
        _mapper = mapper;
        _emailService = emailService;
        _authenticateService = authenticateService;
    }

    public async Task<ReadAdministratorDto> CreateAdministratorAsync(CreateAdministratorDto administratorDto)
    {
        try{
            administratorDto.Password = _authenticateService.HashPassword(administratorDto.Password);
            var administrator = _mapper.Map<Administrator>(administratorDto);
            var administratorCreated = await _administratorRepository.CreateAdministratorAsync(administrator);
            return _mapper.Map<ReadAdministratorDto>(administratorCreated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }

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
        try{
            var administrator = await _administratorRepository.GetAdministratorByIdAsync(id);
            if(administrator == null){
                throw new NotFoundException("Administrador não encontrado");
            }
            _mapper.Map(administratorDto, administrator);
            var administratorUpdated = await _administratorRepository.UpdateAdministratorAsync(administrator);
            return _mapper.Map<ReadAdministratorDto>(administratorUpdated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }

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
    public async Task<string> ResetPassword (string email){
        var administrator = await _administratorRepository.GetAdministratorByEmailAsync(email);
        string newPassword = GenerateNewPassword();
        //string newPassword = "Fermaloc@123";
        var hashedPassword = _authenticateService.HashPassword(newPassword);
        administrator.SetPassword(hashedPassword);
        
        await _emailService.ResetPassword(email, newPassword);
        await _administratorRepository.UpdateAdministratorAsync(administrator);

        return newPassword;
    }

    private static string GenerateNewPassword(){

        const string charUpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string charLowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string charNumbersCase = "0123456789";
        const string charSpecial = "!@#$%^&*()-+";

        var random = new Random();
        var password = new StringBuilder();
        
        password.Append(charUpperCase[random.Next(26)]);
        password.Append(charLowerCase[random.Next(26)]); 
        password.Append(charNumbersCase[random.Next(10)]); 
        password.Append(charSpecial[random.Next(12)]); 

    for (int i = password.Length; i < 8; i++)
    {
        var charSet = charUpperCase + charLowerCase + charNumbersCase + charSpecial;
        password.Append(charSet[random.Next(charSet.Length)]);
    }

        return password.ToString();

    }

}
