using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;


public class StoragesController : BaseController
{
    private readonly IStorageService _storageService;

    public StoragesController(IStorageService storageService)
    {
        _storageService = storageService;
    }
    
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] StorageFilter filter) => Ok(await _storageService.GetAll(filter , Id , filter.PageNumber) , filter.PageNumber);

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromForm] StorageForm storageForm) => Ok(await _storageService.add(Id , storageForm));

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromForm] StorageFormUpdate storageFormUpdate, int id) => Ok(await _storageService.update(storageFormUpdate,id));

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _storageService.delete(id));

    

}