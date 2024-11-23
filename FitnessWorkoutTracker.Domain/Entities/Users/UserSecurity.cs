namespace FitnessWorkoutTracker.Domain.Entities.Users
{
    public class UserSecurity : BaseEntity
    {
        public int UserId { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockOutEndTime { get; set; }

        // Navigations
        public User User { get; set; } = null!;
    }
}
