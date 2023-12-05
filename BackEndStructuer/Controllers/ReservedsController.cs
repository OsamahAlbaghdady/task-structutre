using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.DATA.DTOs.ReservedStorage;
using BackEndStructuer.Entities;
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
    public async Task<ActionResult<List<ReservedStorage>>> GetAll([FromQuery] ReservedStorageFilter filter) => Ok(await _reservedStorageService.GetAll(Id , Role , filter) , filter.PageNumber);

    [HttpPost("{storageId}")]
    public async Task<ActionResult<ReservedStorage>> Create([FromBody] ReservedStorageForm reservedStorage , int storageId) => Ok(await _reservedStorageService.add(Id  , Role,storageId ,reservedStorage));

    [HttpPut("{id}")]
    public async Task<ActionResult<ReservedStorage>> Update([FromBody] ReservedStorageUpdate reservedStorageUpdate, Guid id) => Ok(await _reservedStorageService.update(Role , reservedStorageUpdate,id));
    
}