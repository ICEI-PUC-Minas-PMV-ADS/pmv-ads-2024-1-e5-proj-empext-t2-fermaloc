using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class EquipamentProfile : Profile
{
    public EquipamentProfile()
    {
        CreateMap<Equipament, ReadEquipamentDto>()
            .ForMember(readEquipamentDto => readEquipamentDto.AdministratorDto, opt => opt.MapFrom(equipament => equipament.Administrator))
            .ForMember(readEquipamentDto => readEquipamentDto.CategoryDto, opt => opt.MapFrom(equipament => equipament.Category));
        CreateMap<CreateEquipamentDto, Equipament>();
        CreateMap<UpdateEquipamentDto, Equipament>();
    }
}
