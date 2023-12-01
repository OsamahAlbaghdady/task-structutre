using System.ComponentModel.DataAnnotations;

namespace BackEndStructuer.DATA.DTOs.roles
{
    public class RoleForm
    {
        [Required]
        public string Name { get; set; }
    }
}