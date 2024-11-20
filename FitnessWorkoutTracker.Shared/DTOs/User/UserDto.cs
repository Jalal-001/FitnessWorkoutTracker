﻿namespace FitnessWorkoutTracker.Shared.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FullName { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
    }
}