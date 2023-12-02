using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackEndStructuer.Entities
{
    public class UserStorageBookMark
    {

        public Guid? AppUserId { get; set; }

        public AppUser? AppUser { get; set; }

        public int? StorageId { get; set; }

        public Storage? Storage { get; set; }

        public static implicit operator UserStorageBookMark(EntityEntry<UserStorageBookMark> v)
        {
            throw new NotImplementedException();
        }
    }
}
