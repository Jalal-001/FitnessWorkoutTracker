using FitnessWorkoutTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Persistence.Contexts
{
    public class WorkoutDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserAuthentication> UserAuthentications { get; set; }
        public DbSet<UserSecurity> UserSecurities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User

            modelBuilder.Entity<User>().HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserAuthentications)
                .WithOne(ua => ua.Users)
                .HasForeignKey(ua => ua.UserId)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(u => u.UserSecurities)
                .WithOne(ua => ua.Users)
                .HasForeignKey(ua => ua.UserId)
                .IsRequired();

            modelBuilder.Entity<User>().Property(u => u.UserId).HasColumnType("int");
            modelBuilder.Entity<User>().Property(u => u.Name).HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.Surname).HasColumnType("nvarchar").HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.FullName).HasColumnType("nvarchar").HasMaxLength(100);
            modelBuilder.Entity<User>().Property(u => u.Email).HasColumnType("varchar").HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.CreatedAt).HasColumnType("date");
            modelBuilder.Entity<User>().Property(u => u.UpdatedAt).HasColumnType("date");
            modelBuilder.Entity<User>().Property(u => u.IsActive).HasColumnType("bool");

            #endregion

            #region Roles

            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
            .WithOne(r => r.Role)
            .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Role>().Property(r => r.RoleId).HasColumnType("int");
            modelBuilder.Entity<Role>().Property(r => r.RoleName).HasColumnType("varchar");

            #endregion

            #region UserRoles

            modelBuilder.Entity<UserRole>().HasKey(ur => ur.RoleId);
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).HasColumnType("int");
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).HasColumnType("int");

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
