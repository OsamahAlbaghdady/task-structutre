using BackEndStructuer.DATA.DTOs.User;

namespace BackEndStructuer.DATA.DTOs.RatingStorage;

public class RatingStorageDto
{
    public string? Comment { get; set; }

    public int? Stars { get; set; }

    public UserDto? User { get; set; }
}