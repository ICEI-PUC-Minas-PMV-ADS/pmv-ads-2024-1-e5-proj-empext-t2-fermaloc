﻿using Fermaloc.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Fermaloc.Api;

[ApiController]
[Route("fermaloc/v1/categoria")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCategory ([FromBody] CreateCategoryDto categoryDto){
        var categoryCreated = await _categoryService.CreateCategoryAsync(categoryDto);
        return CreatedAtAction(nameof(GetCategoryById), new { id = categoryCreated.Id }, categoryCreated);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id){
        var categoryDto = await _categoryService.GetCategoryByIdAsync(id);
        return Ok(categoryDto);
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAllCategories(){
        var categoriesDto = await _categoryService.GetAllCategoriesAsync();
        return Ok(categoriesDto);
    }
    
    [HttpGet("status")]
    public async Task<IActionResult> GetCategoriesByStatus([FromQuery] bool status){
        var categoriesDto = await _categoryService.GetCategoriesByStatusAsync(status);
        return Ok(categoriesDto);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateCategory (Guid id, [FromBody] UpdateCategoryDto categoryDto){
        await _categoryService.UpdateCategoryAsync(id, categoryDto);
        return NoContent();
    }
    
    [HttpPut("alterarstatus/{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateCategoryStatus (Guid id){
        await _categoryService.UpdateCategoryStatusAsync(id);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteCategory (Guid id){
        await _categoryService.DeleteCategoryAsync(id);
        return NoContent();
    }
}
