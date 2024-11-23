namespace FitnessWorkoutTracker.Domain.Entities.Users
{
    public class UserAuthentication : AuditableEntity
    {
        public string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public int UserId { get; set; }

        // Navigations
        public required User User { get; set; }
    }
}
