using Fermaloc.Domain;

namespace Fermaloc.Application;

public interface ICategoryService
{
    Task<ReadCategoryDto> CreateCategoryAsync (CreateCategoryDto categoryDto);
    Task<ReadCategoryDto> GetCategoryByIdAsync (Guid id);
    Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync();
    Task<IEnumerable<ReadCategoryDto>> GetCategoriesByStatusAsync(bool status);
    Task<ReadCategoryDto> UpdateCategoryAsync (Guid id, UpdateCategoryDto category);
    Task<ReadCategoryDto> UpdateCategoryStatusAsync (Guid id);    
    Task<ReadCategoryDto>  DeleteCategoryAsync (Guid id);
}
