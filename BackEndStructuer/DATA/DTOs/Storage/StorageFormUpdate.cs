using System.ComponentModel.DataAnnotations;
using BackEndStructuer.Entities;

namespace BackEndStructuer.DATA.DTOs.Storage;

public class StorageFormUpdate
{
    public string? Name { get; set; }
    
    public string? Description { get; set; }

    public int? Price { get; set; }

    
    public double? Lat { get; set; }
    
    
    public double? Lng { get; set; }

    
    public int[]? FeatureIds { get; set; }

    
    public int? GovernmentId { get; set; }

    
    public int? CategoryId { get; set; }
}