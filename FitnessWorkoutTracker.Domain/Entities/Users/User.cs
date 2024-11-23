namespace FitnessWorkoutTracker.Domain.Entities.Users
{
    public class User : AuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public short IsActive { get; set; }
        public bool IsLocked { get; set; }

        // Navigations
        public ICollection<UserRole>? UserRoles { get; } = Array.Empty<UserRole>();
        public required UserAuthentication UserAuthentication { get; set; }
        public ICollection<UserSecurity>? UserSecurities { get; }
    }
}
