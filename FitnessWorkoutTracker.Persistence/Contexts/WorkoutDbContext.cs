﻿using FitnessWorkoutTracker.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FitnessWorkoutTracker.Persistence.Contexts
{
    public class WorkoutDbContext : DbContext
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserAuthentication> UserAuthentications { get; set; }
        public DbSet<UserSecurity> UserSecurities { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
