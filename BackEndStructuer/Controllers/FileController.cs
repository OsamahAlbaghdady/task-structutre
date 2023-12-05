using Microsoft.AspNetCore.Mvc;
using NewEppBackEnd.Services;

namespace BackEndStructuer.Controllers;

public class FileController : BaseController
{
    private readonly IFileService _fileService;

    public FileController(IFileService fileService)
    {
        _fileService = fileService;
    }

    [HttpPost]
    public async Task<ActionResult<(string? file, string? error)>> UploadFile([FromForm] IFormFile file) => Ok(await _fileService.Upload(file)) ;
    
    [HttpPost("multi")]
    public async Task<ActionResult<(List<string>? files, string? error)>> UploadFile([FromForm] IFormFile[] files) => Ok(await _fileService.Upload(files)) ;
}