using System.ComponentModel.DataAnnotations;

namespace BackEndStructuer.DATA.DTOs.RatingStorage;

public class RatingStorageForm
{
    [Required]
    public int? Stars { get; set; }

    public string? Comment { get; set; }
}