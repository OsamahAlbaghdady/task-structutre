using BackEndStructuer.DATA.DTOs.RatingStorage;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;


public class RatingStoragesController : BaseController
{
    private readonly IRatingStorageService _ratingStorageService;

    public RatingStoragesController(IRatingStorageService ratingStorageService)
    {
        _ratingStorageService = ratingStorageService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] RatingStorageFilter filter) =>
        Ok(await _ratingStorageService.GetAll(filter) , filter.PageNumber);


    [Authorize]
    [HttpPost("{storageId}")]
    public async Task<IActionResult> Add([FromForm] RatingStorageForm ratingStorageForm, int storageId) =>
        Ok(await _ratingStorageService.Add(Id, storageId, ratingStorageForm));

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update(Guid id, RatingStorageUpdate ratingStorageUpdate) =>
        Ok(_ratingStorageService.Update(id, ratingStorageUpdate));

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id) => Ok(_ratingStorageService.Delete(id));


}