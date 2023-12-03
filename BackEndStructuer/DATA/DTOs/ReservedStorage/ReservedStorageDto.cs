using BackEndStructuer.DATA.DTOs.Storage;
using BackEndStructuer.DATA.DTOs.User;

namespace BackEndStructuer.DATA.DTOs.ReservedStorage;

public class ReservedStorageDto
{
    public Guid? Id { get; set; }

    public String? Destination { get; set; }
    
    public String? Type { get; set; }

    public int? Count { get; set; }
    
    public UserDto? User { get; set; }

    public StorageDto? Storage { get; set; }

    public DateTime? StartDate { get; set; }
    
    public DateTime? EndDate { get; set; }
}