using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {        
        CreateMap<Category, ReadCategoryDto>()
            .ForMember(readCategoryDto => readCategoryDto.AdministratorDto, opt => opt.MapFrom(category => category.Administrator));
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}
