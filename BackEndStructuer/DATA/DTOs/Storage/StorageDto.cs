using BackEndStructuer.DATA.DTOs.Category;
using BackEndStructuer.Entities;

namespace BackEndStructuer.DATA.DTOs.Storage;

public class StorageDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int Price { get; set; }

    public double Lat { get; set; }
    
    public double Lng { get; set; }

    public ICollection<FeatureDto> Features { get; set; }
    
    public GovernmentDto Government { get; set; }

    public CategoryDto Category { get; set; }

    public DateTime CreationDate { get; set; }
}