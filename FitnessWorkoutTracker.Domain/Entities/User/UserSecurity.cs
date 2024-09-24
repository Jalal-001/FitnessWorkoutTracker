namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class UserSecurity
    {
        public int UserId { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockOutEndTime { get; set; }

        // For Table Relationships
        public User Users { get; set; } = null!;
    }
}
