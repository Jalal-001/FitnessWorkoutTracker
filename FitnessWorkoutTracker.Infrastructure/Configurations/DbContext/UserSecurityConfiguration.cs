using FitnessWorkoutTracker.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTracker.Infrastructure.Configurations.DbContext
{
    public class UserSecurityConfiguration : IEntityTypeConfiguration<UserSecurity>
    {
        public void Configure(EntityTypeBuilder<UserSecurity> builder)
        {
            builder.HasKey(us => us.UserId);
            builder.HasKey(us => us.UserId);
        }
    }
}
