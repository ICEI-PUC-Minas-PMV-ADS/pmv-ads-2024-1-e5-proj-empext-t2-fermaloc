using AutoMapper;
using Fermaloc.Application.DTOs.EquipamentClicksDTO;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class EquipamentClicksProfile : Profile
{
    public EquipamentClicksProfile()
    {
        CreateMap<EquipamentClicks, EquipamentClicksDto>().ReverseMap();
    }
}