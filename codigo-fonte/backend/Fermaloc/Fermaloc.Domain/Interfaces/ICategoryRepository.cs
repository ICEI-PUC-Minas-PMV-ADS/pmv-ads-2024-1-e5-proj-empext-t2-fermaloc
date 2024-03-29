﻿namespace Fermaloc.Domain;

public interface ICategoryRepository
{
    Task<Category> CreateCategoryAsync (Category category);
    Task<Category> GetCategoryByIdAsync (Guid id);
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<IEnumerable<Category>> GetCategoriesByStatusAsync(bool status);
    Task<Category> UpdateCategoryAsync (Category category);
    Task<Category> UpdateCategoryStatusAsync (Category category);
    Task<Category>  DeleteCategoryAsync (Category category);
}
