using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.DATA.DTOs.ReservedStorage;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;

public class ReservedsController : BaseController
{
    private readonly IReservedStorageService _reservedStorageService;

    public ReservedsController(IReservedStorageService reservedStorageService)
    {
        _reservedStorageService = reservedStorageService;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] BaseFilter filter) => Ok(await _reservedStorageService.GetAll(Id , filter.PageNumber) , filter.PageNumber);

    [HttpPost("{storageId}")]
    public async Task<IActionResult> Create([FromForm] ReservedStorageForm reservedStorage , int storageId) => Ok(await _reservedStorageService.add(Id ,storageId ,reservedStorage));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromForm] ReservedStorageUpdate reservedStorageUpdate, Guid id) => Ok(await _reservedStorageService.update(reservedStorageUpdate,id));
    
}