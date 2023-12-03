using System.ComponentModel.DataAnnotations;

namespace BackEndStructuer.DATA.DTOs.ReservedStorage;

public class ReservedStorageForm
{

    [Required]
    public String Destination { get; set; }
    
    [Required]
    public String Type { get; set; }

    [Required]
    public int Count { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
}