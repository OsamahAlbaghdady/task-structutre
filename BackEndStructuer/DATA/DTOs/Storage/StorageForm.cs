using System.ComponentModel.DataAnnotations;
using BackEndStructuer.Entities;

namespace BackEndStructuer.DATA.DTOs.Storage;

public class StorageForm
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public double Lat { get; set; }
    
    [Required]
    public double Lng { get; set; }

    [Required]
    public List<int> FeatureIds { get; set; }

    [Required]
    public int GovernmentId { get; set; }

    [Required]
    public int CategoryId { get; set; }
    
    [Required] public IFormFile[] Files { get; set; }

}