using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;


public class CategoriesController : BaseController
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }


    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAll([FromQuery] CategoryFilter filter) => Ok(await _categoryService.GetAll(filter) , filter.PageNumber);

    [HttpPost]
    public async Task<ActionResult<Category>> Create([FromBody] CategoryForm categoryForm) => Ok(await _categoryService.add(categoryForm));

    [HttpPut("{id}")]
    public async Task<ActionResult<Category>> Update([FromBody] CategoryFormUpdate categoryFormUpdate, int id) => Ok(await _categoryService.update(categoryFormUpdate,id));

    [HttpDelete("{id}")]
    public async Task<ActionResult<Category>> Delete(int id) => Ok(await _categoryService.delete(id));
    
    
 
}