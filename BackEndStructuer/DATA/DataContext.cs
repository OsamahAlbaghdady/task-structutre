using BackEndStructuer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndStructuer.DATA
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Feature> Features { get; set; }
        
        public DbSet<Article> Articles { get; set; }

        public UserStorageBookMark UserStorageBookMark { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<RolePermission>().HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<UserStorageBookMark>().HasKey(usbm => new { usbm.StorageId, usbm.AppUserId });

            // new DbInitializer(modelBuilder).Seed();
        

        }

    }
}