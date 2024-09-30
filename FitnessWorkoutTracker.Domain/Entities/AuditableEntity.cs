namespace FitnessWorkoutTracker.Domain.Entities
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public EntityStatus Status { get; set; } = EntityStatus.Active;

        public AuditableEntity()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
    public enum EntityStatus
    {
        Active = 1,
        Inactive = 2,
    }
}
