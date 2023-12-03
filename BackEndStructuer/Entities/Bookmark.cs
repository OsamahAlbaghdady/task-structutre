using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackEndStructuer.Entities
{
    public class Bookmark : BaseEntity<int>
    {

        public Guid? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public int? StorageId { get; set; }

        public Storage? Storage { get; set; }

   
    }
}
