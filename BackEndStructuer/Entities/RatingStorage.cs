namespace BackEndStructuer.Entities;

public class RatingStorage : BaseEntity<Guid>
{
    public Guid? UserId { get; set; }
    
    public AppUser? User { get; set; }

    public int? StorageId { get; set; }
    
    public Storage? Storage { get; set; }

    public int? Stars { get; set; }
    
    public string? Comment { get; set; }
}