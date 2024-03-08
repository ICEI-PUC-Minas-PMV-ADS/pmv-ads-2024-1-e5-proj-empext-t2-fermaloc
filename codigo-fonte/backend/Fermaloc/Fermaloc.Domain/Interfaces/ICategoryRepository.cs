namespace Fermaloc.Domain;

public interface ICategoryRepository
{
    Task<Category> CreateCategoryAsync (Category category);
    Task<Category> GetCategoryByIdAsync (Guid id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> UpdateCategoryAsync (Category category);
    Task<Category>  DeleteCategoryAsync (Guid id);
}
