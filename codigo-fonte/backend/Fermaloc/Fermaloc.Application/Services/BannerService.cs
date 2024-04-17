using AutoMapper;
using Fermaloc.Domain;
using Fermaloc.Domain.Validations;

namespace Fermaloc.Application;

public class BannerService : IBannerService
{
    private readonly IBannerRepository _bannerRepository;
    private readonly IMapper _mapper;

    public BannerService(IBannerRepository bannerRepository, IMapper mapper)
    {
        _bannerRepository = bannerRepository;
        _mapper = mapper;
    }

    public async Task<ReadBannerDto> CreateBannerAsync(CreateBannerDto bannerDto, byte[] image)
    {
        try{
            var banner = _mapper.Map<Banner>(bannerDto);
            banner.SetImage(image);
            var bannerCreated = await _bannerRepository.CreateBannerAsync(banner);
            return _mapper.Map<ReadBannerDto>(bannerCreated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }

    }
    public async Task<ReadBannerDto> GetBannerAsync()
    {
        var banner = await _bannerRepository.GetBannerAsync();
        if(banner == null){
            throw new NotFoundException("Nenhum banner encontrado");
        }        
        var bannerDto = _mapper.Map<ReadBannerDto>(banner);
        return bannerDto;
    }
    public async Task<ReadBannerDto> UpdateBannerAsync(byte[] image)
    {
        try{
            var banner = await _bannerRepository.GetBannerAsync();
            if(banner == null){
                throw new NotFoundException("Nenhum banner encontrado");
            }
            banner.SetImage(image);
            var bannerUpdated = await _bannerRepository.UpdateBannerAsync(banner);
            return _mapper.Map<ReadBannerDto>(bannerUpdated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }
    }
    public async Task<ReadBannerDto> DeleteBannerAsync()
    {
        var banner = await _bannerRepository.GetBannerAsync();
        if(banner == null){
            throw new NotFoundException("Nenhum banner encontrado");
        }        
        var bannerDeleted = await _bannerRepository.DeleteBannerAsync(banner);
        return _mapper.Map<ReadBannerDto>(bannerDeleted);
    }
}
