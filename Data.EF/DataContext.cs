using Data.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.EF
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Office> Offices { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTask> Tasks { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPermission>()
                .HasKey(userPerm => new { userPerm.UserId, userPerm.PermissionId });

            modelBuilder.Entity<UserPermission>()
                .HasOne(userPerm => userPerm.Permission)
                .WithMany(perm => perm.Permissions)
                .HasForeignKey(userPerm => userPerm.PermissionId);

            modelBuilder.Entity<UserPermission>()
                .HasOne(userPerm => userPerm.User)
                .WithMany(user => user.Permissions)
                .HasForeignKey(userPerm => userPerm.UserId);
        }
    }
}
