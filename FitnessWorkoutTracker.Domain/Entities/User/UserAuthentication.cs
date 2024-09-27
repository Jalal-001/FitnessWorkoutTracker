namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class UserAuthentication
    {
        public int UserId { get; set; }
        public string PasswordHash { get; set; }
        public string PassWordSalt { get; set; }
        public string? RefreshToken { get; set; }

        // For Table Relationships
        public User User { get; set; } = null!;
    }
}
