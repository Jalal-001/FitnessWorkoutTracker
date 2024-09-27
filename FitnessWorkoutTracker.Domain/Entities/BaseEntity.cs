namespace FitnessWorkoutTracker.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public EntityStatus Status { get; set; } = EntityStatus.Active;
        public string? Description { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }
        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
        // Method to update the timestamp when the entity is modified
        public void UpdateTimestamp()
        {
            UpdatedDate = DateTime.UtcNow;
        }
    }
    public enum EntityStatus
    {
        Active = 1,
        Inactive = 2,
    }
}
