namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        // For Table Relationships
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
