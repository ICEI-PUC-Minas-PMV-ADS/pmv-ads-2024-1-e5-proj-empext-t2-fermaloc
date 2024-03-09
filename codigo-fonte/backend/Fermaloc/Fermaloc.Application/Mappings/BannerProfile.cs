using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class BannerProfile : Profile
{
    public BannerProfile()
    {
        CreateMap<Banner, ReadBannerDto>()
            .ForMember(readBannerDto => readBannerDto.AdministratorDto, opt => opt.MapFrom(banner => banner.Administrator));
        CreateMap<CreateBannerDto, Banner>();
    }
}
