using FitnessWorkoutTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTracker.Infrastructure.Configurations.DbContext
{
    public class UserAuthenticationConfiguration : IEntityTypeConfiguration<UserAuthentication>
    {
        public void Configure(EntityTypeBuilder<UserAuthentication> builder)
        {
            builder.HasKey(ua => ua.UserId);
            builder.HasIndex(ua => ua.UserId).IsUnique();
        }
    }
}
