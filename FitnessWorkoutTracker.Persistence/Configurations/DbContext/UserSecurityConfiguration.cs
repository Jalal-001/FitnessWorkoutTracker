using FitnessWorkoutTracker.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessWorkoutTracker.Persistence.Configurations.DbContext
{
    public class UserSecurityConfiguration : IEntityTypeConfiguration<UserSecurity>
    {
        public void Configure(EntityTypeBuilder<UserSecurity> builder)
        {
            builder.HasKey(us => us.Id);
            builder.Ignore(us => us.User);
            builder.HasIndex(us => us.Id).IsUnique();
        }
    }
}
