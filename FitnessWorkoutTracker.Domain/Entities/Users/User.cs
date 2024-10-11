namespace FitnessWorkoutTracker.Domain.Entities.Users
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        // Navigations
        public ICollection<UserRole> UserRoles { get; } = Array.Empty<UserRole>();
        public UserAuthentication UserAuthentication { get; } = null!;
        public ICollection<UserSecurity> UserSecurities { get; } = null!;
    }
}
