using AutoMapper;
using Fermaloc.Domain;

namespace Fermaloc.Application;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<ReadCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var category = _mapper.Map<Category>(categoryDto);
        category.Status = true;
        var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);
        return _mapper.Map<ReadCategoryDto>(categoryCreated);
    }
    public async Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        var categoryDto = _mapper.Map<ReadCategoryDto>(category);
        return categoryDto;
    }
    public async Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryRepository.GetAllCategoriesAsync();
        IEnumerable<ReadCategoryDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadCategoryDto>>(categories);
        return readCategoriesDto;
    }
    public async Task<IEnumerable<ReadCategoryDto>> GetCategoriesByStatusAsync(bool status)
    {
        var categories = await _categoryRepository.GetCategoriesByStatusAsync(status);
        IEnumerable<ReadCategoryDto> readCategoriesDto = _mapper.Map<IEnumerable<ReadCategoryDto>>(categories);
        return readCategoriesDto;
    }
    public async Task<ReadCategoryDto> UpdateCategoryAsync(Guid id, UpdateCategoryDto categoryDto)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        _mapper.Map(categoryDto, category);
        var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(category);
        return _mapper.Map<ReadCategoryDto>(categoryUpdated);
    }
    public async Task<ReadCategoryDto> UpdateCategoryStatusAsync(Guid id)
    {
        var equipamentUpdated = await _categoryRepository.UpdateCategoryStatusAsync(id);
        return _mapper.Map<ReadCategoryDto>(equipamentUpdated);
    }
    public async Task<ReadCategoryDto> DeleteCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.DeleteCategoryAsync(id);
        return _mapper.Map<ReadCategoryDto>(category);
    }
}
