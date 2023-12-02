using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BackEndStructuer.Entities
{
    public class AppUser : BaseEntity<Guid>
    {
        public string? Email { get; set; }
        
        public string? FullName { get; set; }
        
        public string? Password { get; set; }
        
        public int? RoleId { get; set; }
        public Role? Role { get; set; }

        public ICollection<UserStorageBookMark> UserStorageBookMarks { get; set; } = new List<UserStorageBookMark>();

    }
    
}