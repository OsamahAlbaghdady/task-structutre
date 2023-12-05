using BackEndStructuer.DATA.DTOs;
using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.Entities;
using BackEndStructuer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndStructuer.Controllers;

public class BookMarkSController : BaseController
{

    private IBookMarkService _bookMarkService;

    public BookMarkSController(IBookMarkService bookMarkService)
    {
        _bookMarkService = bookMarkService;
    }

    [HttpPost("{storageId}")]
    public async Task<ActionResult<Bookmark>> AddBookMark(int storageId) => Ok(await _bookMarkService.add(Id , storageId));

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<StorageDto>>> GetBookMark([FromQuery] BaseFilter filter) => Ok(await _bookMarkService.GetAll(Id , filter.PageNumber) , filter.PageNumber);
    
    
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Bookmark>> DeleteBookmark(int id) => Ok(await _bookMarkService.delete( id ));
}