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


    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter) => Ok(await _storageService.GetAll(Id , filter.PageNumber) , filter.PageNumber);
    
    [HttpGet("GetNearby")]
    public async Task<IActionResult> GetNearby([FromQuery] BaseFilter filter) => Ok(await _storageService.GetNearbyStorages(Id , filter.PageNumber) , filter.PageNumber);

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] StorageForm storageForm) => Ok(await _storageService.add(Id , storageForm));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromForm] StorageFormUpdate storageFormUpdate, int id) => Ok(await _storageService.update(storageFormUpdate,id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => Ok(await _storageService.delete(id));

    

}