using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessWorkoutTracker.Domain.Entities.User
{
    public class Role : AuditableEntity
    {
        public string RoleName { get; set; }

        // Navigations
        public ICollection<UserRole> UserRoles { get; set; } = null!;
    }
}
