using BackEndStructuer.Utils.Enums;

namespace BackEndStructuer.Entities;

public class ReservedStorage : BaseEntity<Guid>
{
    public Guid? UserId { get; set; }

    public String? Destination { get; set; }
    
    public String? Type { get; set; }

    public int? Count { get; set; }
    
    public AppUser? User { get; set; }

    public int? StorageId { get; set; }
    
    public Storage? Storage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public ReserveState? State { get; set; }

}