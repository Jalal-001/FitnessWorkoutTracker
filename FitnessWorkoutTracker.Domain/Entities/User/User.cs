﻿namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        // For Table Relationships
        public ICollection<UserRole> UserRoles { get; } = null!;
        public UserAuthentication UserAuthentication { get; } = null!;
        public ICollection<UserSecurity> UserSecurities { get; } = null!;
    }
}
