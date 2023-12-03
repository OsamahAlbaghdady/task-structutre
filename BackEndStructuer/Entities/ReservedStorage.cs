namespace BackEndStructuer.Entities;

public class ReservedStorage 
{
    public Guid? AppUserId { get; set; }
    
    public AppUser? AppUser { get; set; }

    public int? StorageId { get; set; }
    
    public Storage? Storage { get; set; }

    public DateTime? StartReserved { get; set; }
    
    public DateTime? EndReserved { get; set; }
}