namespace BackEndStructuer.Entities;

public class Storage : BaseEntity<int>
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }

    public int? Price { get; set; }

    public double? Lat { get; set; }
    
    public double? Lng { get; set; }

    public int? NumberOfRom { get; set; }
    
    public string? Space { get; set; }

    public bool IsReserved { get; set; } = false;

    public int? GovernmentId { get; set; }
    
    public Government? Government { get; set; }
    
    public int? CategoryId { get; set; }

    public Category? Category { get; set; }

    public ICollection<Feature>? Features { get; set; }

    public ICollection<StorageFile>? Files { get; set; } = new List<StorageFile>();


}