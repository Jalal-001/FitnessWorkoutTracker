using FitnessWorkoutTracker.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTracker.Persistence.Configurations.DbContext
{
    public class UserAuthenticationConfiguration : IEntityTypeConfiguration<UserAuthentication>
    {
        public void Configure(EntityTypeBuilder<UserAuthentication> builder)
        {
            builder.HasKey(ua => ua.Id);
            builder.Property(ua => ua.PasswordHash).HasMaxLength(128);
            builder.Property(ua => ua.PasswordHash).HasMaxLength(128);
            builder.HasIndex(ua => ua.Id).IsUnique();
        }
    }
}
