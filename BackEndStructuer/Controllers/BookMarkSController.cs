using BackEndStructuer.DATA.DTOs;
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
    public async Task<IActionResult> AddBookMark(int storageId) => Ok(await _bookMarkService.add(Id , storageId));

    [Authorize]
    [HttpGet()]
    public async Task<IActionResult> GetBookMark([FromQuery] BaseFilter filter) => Ok(await _bookMarkService.GetAll(Id , filter.PageNumber) , filter.PageNumber);
    
    
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBookmark(int id) => Ok(await _bookMarkService.delete( id ));
}