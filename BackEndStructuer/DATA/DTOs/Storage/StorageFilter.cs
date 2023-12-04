using BackEndStructuer.Entities;

namespace BackEndStructuer.DATA.DTOs.Storage;

public class StorageFilter : BaseFilter
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public int? MinPrice { get; set; }
    
    public int? MaxPrice { get; set; }

    public double? Lat { get; set; }
    
    public double? Lng { get; set; }

    public int? Distance { get; set; }

    public int? NumberOrRoom { get; set; }

    public bool? IsReserved { get; set; }
    public bool? IsOwner { get; set; }
    
    public int? GovernmentId { get; set; }
    
    public int? CategoryId { get; set; }
    
    public List<int>? Features { get; set; }
    
}