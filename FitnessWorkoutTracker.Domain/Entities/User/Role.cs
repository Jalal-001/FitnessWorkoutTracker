namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string RoleName { get; set; }

        // For Table Relationships
        public ICollection<UserRole> UserRoles { get; set; } = null!;
    }
}
