using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class UserRole:AuditableEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        // Navigations
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}
