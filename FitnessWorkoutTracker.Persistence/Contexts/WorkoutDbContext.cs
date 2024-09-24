using FitnessWorkoutTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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

            #region Role

            modelBuilder.Entity<Role>().HasKey(r => r.RoleId);
            modelBuilder.Entity<Role>()
                .HasMany(r => r.UserRoles)
            .WithOne(r => r.Role)
            .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Role>().Property(r => r.RoleId).HasColumnType("int");
            modelBuilder.Entity<Role>().Property(r => r.RoleName).HasColumnType("varchar");

            #endregion

            #region UserRole

            modelBuilder.Entity<UserRole>().HasKey(ur => ur.RoleId);
            modelBuilder.Entity<UserRole>().Property(ur => ur.RoleId).HasColumnType("int");
            modelBuilder.Entity<UserRole>().Property(ur => ur.UserId).HasColumnType("int");

            #endregion


            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
