namespace FitnessWorkoutTracker.Domain.Entities
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
    }
    public enum EntityStatus
    {
        Active = 1,
        Inactive = 2,
    }
}
