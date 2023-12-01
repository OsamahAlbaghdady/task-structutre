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

    public ICollection<Feature> Features { get; set; }
    
    public Government Government { get; set; }

    public Entities.Category Category { get; set; }
}