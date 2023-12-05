using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.Entities;
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
    public async Task<ActionResult<List<StorageDto>>> GetAll([FromQuery] StorageFilter filter) => Ok(await _storageService.GetAll(Role , filter , Id , filter.PageNumber) , filter.PageNumber);

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Storage>> Create([FromBody] StorageForm storageForm) => Ok(await _storageService.add(Id , storageForm));

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<Storage>> Update([FromBody] StorageFormUpdate storageFormUpdate, int id) => Ok(await _storageService.update(storageFormUpdate,id));

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<Storage>> Delete(int id) => Ok(await _storageService.delete(id));

    

}