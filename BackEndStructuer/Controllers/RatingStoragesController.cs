using BackEndStructuer.DATA.DTOs.RatingStorage;
using BackEndStructuer.Entities;
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
    public async Task<ActionResult<List<RatingStorageDto>>> GetAll([FromQuery] RatingStorageFilter filter) =>
        Ok(await _ratingStorageService.GetAll(filter) , filter.PageNumber);


    [Authorize]
    [HttpPost("{storageId}")]
    public async Task<ActionResult<RatingStorage>> Add([FromBody] RatingStorageForm ratingStorageForm, int storageId) =>
        Ok(await _ratingStorageService.Add(Id, storageId, ratingStorageForm));

    [Authorize]
    [HttpPut("{id}")]
    public async Task<ActionResult<RatingStorage>> Update(Guid id, [FromBody] RatingStorageUpdate ratingStorageUpdate) =>
        Ok(_ratingStorageService.Update(id, ratingStorageUpdate));

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult<RatingStorage>> Delete(Guid id) => Ok(_ratingStorageService.Delete(id));


}