namespace BackEndStructuer.DATA.DTOs.ReservedStorage;

public class ReservedStorageUpdate
{
    public int? StorageId { get; set; }
    
    public String? Destination { get; set; }
    
    public String? Type { get; set; }

    public int? Count { get; set; }
    
    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
}