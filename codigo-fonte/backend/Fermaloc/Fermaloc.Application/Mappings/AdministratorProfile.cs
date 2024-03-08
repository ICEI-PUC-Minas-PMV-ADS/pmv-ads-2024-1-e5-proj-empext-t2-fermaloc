using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class AdministratorProfile : Profile
{
    public AdministratorProfile()
    {
        CreateMap<Administrator, ReadAdministratorDto>();
        CreateMap<CreateAdministratorDto, Administrator>();
        CreateMap<UpdateAdministratorDto, Administrator>();
    }
}
