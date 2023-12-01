using BackEndStructuer.DATA.DTOs.File;
using BackEndStructuer.Utils;

namespace BackEndStructuer.Services.Files
{
}

namespace NewEppBackEnd.Services
{
    
    public interface IFileService {
        Task<(FileDto? file, string? error)> Upload(IFormFile file);
        Task<(List<FileDto>? files, string? error)> Upload(IFormFile[] files);
    }
    
    public class FileService  : IFileService
    {

        public async Task<(FileDto? file, string? error)> Upload(IFormFile file) {
            var id = Guid.NewGuid();
            var extension = Path.GetExtension(file.FileName);
            var fileName = $"{id}{extension}";

            var attachmentsDir = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "Attachments");
            if (!File.Exists(attachmentsDir)) Directory.CreateDirectory(attachmentsDir);


            var path = Path.Combine(attachmentsDir, fileName);
            await using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            var filePath = Path.Combine("Attachments", fileName);
            var fileDto = new FileDto {
                Path = filePath,
            };
            return (fileDto, null);
        }
        public async Task<(List<FileDto>? files, string? error)> Upload(IFormFile[] files)
        {
            var fileDtos = new List<FileDto>();
            foreach (var file in files)
            {
                var (fileDto, error) = await Upload(file);
                if (error != null) return (null, error);
                fileDtos.Add(fileDto!);
            }
            return (fileDtos, null);
        }
    }
}