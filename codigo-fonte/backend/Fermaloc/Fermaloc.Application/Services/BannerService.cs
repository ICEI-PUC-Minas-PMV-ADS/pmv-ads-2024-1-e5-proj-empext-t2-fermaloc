using AutoMapper;
using Fermaloc.Domain;

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
        var banner = _mapper.Map<Banner>(bannerDto);
        banner.SetImage(image);
        var bannerCreated = await _bannerRepository.CreateBannerAsync(banner);
        return _mapper.Map<ReadBannerDto>(bannerCreated);
    }
    public async Task<ReadBannerDto> GetBannerByIdAsync(Guid id)
    {
        var banner = await _bannerRepository.GetBannerByIdAsync(id);
        if(banner == null){
            throw new NotFoundException("Banner não encontrado");
        }        
        var bannerDto = _mapper.Map<ReadBannerDto>(banner);
        return bannerDto;
    }
    public async Task<ReadBannerDto> UpdateBannerAsync(Guid id, byte[] image)
    {
        var banner = await _bannerRepository.GetBannerByIdAsync(id);
        if(banner == null){
            throw new NotFoundException("Banner não encontrado");
        }
        banner.SetImage(image);
        var bannerUpdated = await _bannerRepository.UpdateBannerAsync(banner);
        return _mapper.Map<ReadBannerDto>(bannerUpdated);
    }
    public async Task<ReadBannerDto> DeleteBannerAsync(Guid id)
    {
        var banner = await _bannerRepository.GetBannerByIdAsync(id);
        if(banner == null){
            throw new NotFoundException("Banner não encontrado");
        }        
        var bannerDeleted = await _bannerRepository.DeleteBannerAsync(banner);
        return _mapper.Map<ReadBannerDto>(bannerDeleted);
    }
}
