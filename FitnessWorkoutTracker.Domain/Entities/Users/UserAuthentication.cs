using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessWorkoutTracker.Domain.Entities.Users
{
    public class UserAuthentication : AuditableEntity
    {
        public string PasswordHash { get; set; }
        public string PassWordSalt { get; set; }
        public string? RefreshToken { get; set; }

        // Navigations
        public User User { get; set; } = null!;
    }
}
