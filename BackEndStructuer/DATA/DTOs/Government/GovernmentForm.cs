using System.ComponentModel.DataAnnotations;

namespace BackEndStructuer.DATA.DTOs.Category;

public class GovernmentForm
{
    [Required]
    public string Name { get; set; }
    
}