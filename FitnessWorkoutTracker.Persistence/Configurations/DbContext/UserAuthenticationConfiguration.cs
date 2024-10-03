using FitnessWorkoutTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTracker.Persistence.Configurations.DbContext
{
    public class UserAuthenticationConfiguration : IEntityTypeConfiguration<UserAuthentication>
    {
        public void Configure(EntityTypeBuilder<UserAuthentication> builder)
        {
            builder.HasKey(ua => ua.Id);
            builder.Ignore(ua => ua.User);
            builder.Property(ua => ua.PasswordHash).HasMaxLength(128);
            builder.Property(ua => ua.PassWordSalt).HasMaxLength(8);
            builder.Property(ua => ua.PasswordHash).HasMaxLength(128);
            builder.HasIndex(ua => ua.Id).IsUnique();
        }
    }
}
