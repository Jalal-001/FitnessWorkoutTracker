namespace FitnessWorkoutTracker.Shared.DTOs
{
    public class UserDto
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
