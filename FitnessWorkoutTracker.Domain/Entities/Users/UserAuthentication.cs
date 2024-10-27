namespace FitnessWorkoutTracker.Domain.Entities.Users
{
    public class UserAuthentication : AuditableEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PassWordSalt { get; set; }
        public string? RefreshToken { get; set; }

        // Navigations
        public User User { get; set; } = null!;
    }
}
