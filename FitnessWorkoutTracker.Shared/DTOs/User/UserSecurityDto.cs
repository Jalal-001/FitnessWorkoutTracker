namespace FitnessWorkoutTracker.Shared.DTOs.User
{
    public class UserSecurityDto
    {
        public int UserId { get; set; }
        public int FailedLoginAttempts { get; set; }
        public DateTime? LockOutEndTime { get; set; }
    }
}
