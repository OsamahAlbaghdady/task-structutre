namespace BackEndStructuer.DATA.DTOs.RatingStorage;

public class RatingStorageFilter : BaseFilter
{
    public int? StorageId { get; set; }

    public string? Comment { get; set; }

    public int? Stars { get; set; }
}