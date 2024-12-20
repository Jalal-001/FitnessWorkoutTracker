﻿using FitnessWorkoutTracker.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTracker.Persistence.Configurations.DbContext
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(u => u.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.HasOne(u => u.UserAuthentication)
                .WithOne(ua => ua.User)
                .HasForeignKey<UserAuthentication>(ua => ua.UserId)
                .IsRequired();

            builder.HasMany(u => u.UserSecurities)
                .WithOne(ua => ua.User)
                .HasForeignKey(ua => ua.UserId)
                .IsRequired();

            builder.Property(u => u.Name)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(u => u.Surname)
                .IsUnicode()
                .HasMaxLength(50);

            builder.Property(u => u.FullName)
                .IsUnicode()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(50);

            builder.Property(u => u.IsActive)
                .HasDefaultValue(1);

            builder.HasIndex(u => u.Id).IsUnique();
        }
    }
}
