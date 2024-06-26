﻿using AutoMapper;
using Fermaloc.Domain;
using Fermaloc.Domain.Validations;

namespace Fermaloc.Application;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAdministratorRepository _administratorRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IAdministratorRepository administratorRepository)
    {
        _categoryRepository = categoryRepository;
        _administratorRepository = administratorRepository;
        _mapper = mapper;
    }
    public async Task<ReadCategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        try{
            var category = _mapper.Map<Category>(categoryDto);
            var categoryAdministrator = await _administratorRepository.GetAdministratorByIdAsync(categoryDto.AdministratorId);
            if(categoryAdministrator == null){
                throw new InvalidDataException("Administrador não encontrado");
            }
            var categoryCreated = await _categoryRepository.CreateCategoryAsync(category);
            return _mapper.Map<ReadCategoryDto>(categoryCreated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }
    }
    public async Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if(category == null){
            throw new NotFoundException("Categoria não encontrado");
        }          
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
        try{
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            if(category == null){
                throw new NotFoundException("Categoria não encontrado");
            }          
            _mapper.Map(categoryDto, category);
            if(category.Status == false){
                foreach(var equipament in category.Equipaments){
                    equipament.SetStatus(category.Status);
                }
            }
            var categoryUpdated = await _categoryRepository.UpdateCategoryAsync(category);
            return _mapper.Map<ReadCategoryDto>(categoryUpdated);
        }catch(DomainExceptionValidation ex){
            throw new InvalidDataException(ex.Message);
        }
    }
    
    public async Task<ReadCategoryDto> UpdateCategoryStatusAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if(category == null){
            throw new NotFoundException("Categoria não encontrado");
        }          
        category.SetStatus(!category.Status);
        if(!category.Status){
            foreach(var equipament in category.Equipaments){
                equipament.SetStatus(category.Status);
            }
        }

        var categoryUpdated = await _categoryRepository.UpdateCategoryStatusAsync(category);
        return _mapper.Map<ReadCategoryDto>(categoryUpdated);
    }
    public async Task<ReadCategoryDto> DeleteCategoryAsync(Guid id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if(category == null){
            throw new NotFoundException("Categoria não encontrado");
        }        
        var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(category);
        return _mapper.Map<ReadCategoryDto>(categoryDeleted);
    }
}
