namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class UserAuthentication
    {
        public int UserId { get; set; }
        public required string PasswordHash { get; set; }
        public required string PassWordSalt { get; set; }
        public string? RefreshToken { get; set; }

        // For Table Relationships
        public User User { get; set; } = null!;
    }
}
