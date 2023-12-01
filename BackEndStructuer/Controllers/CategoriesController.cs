using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
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
    public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter) => Ok(await _categoryService.GetAll(filter.PageNumber) , filter.PageNumber);

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CategoryForm categoryForm  , IFormFile Image) => Ok(await _categoryService.add(categoryForm , Image));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromForm] CategoryFormUpdate categoryFormUpdate, int id) => Ok(await _categoryService.update(categoryFormUpdate,id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _categoryService.delete(id));
    
    
 
}