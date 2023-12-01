using System.ComponentModel.DataAnnotations;

namespace BackEndStructuer.DATA.DTOs.Category;

public class FeatureForm
{
    [Required]
    public string Name { get; set; }
    
}