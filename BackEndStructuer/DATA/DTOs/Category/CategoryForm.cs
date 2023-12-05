using System.ComponentModel.DataAnnotations;

namespace BackEndStructuer.DATA.DTOs.Category;

public class CategoryForm
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Image { get; set; }
    
}