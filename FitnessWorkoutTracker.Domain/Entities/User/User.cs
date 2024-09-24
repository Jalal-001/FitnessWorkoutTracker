namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class User
    {
        public int UserId { get; set; }
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string FullName { get; set; }
        public string? Email { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required DateTime UpdatedAt { get; set; }
        public required bool IsActive { get; set; }

        // For Table Relationships
        public ICollection<UserRole> UserRoles { get; } = null!;
        public ICollection<UserAuthentication> UserAuthentications { get; } = null!;
        public ICollection<UserSecurity> UserSecurities { get; } = null!;
    }
}
