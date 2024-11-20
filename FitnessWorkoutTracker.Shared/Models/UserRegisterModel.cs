using FitnessWorkoutTracker.Shared.DTOs.User;

namespace FitnessWorkoutTracker.Shared.Models
{
    public class UserRegisterModel
    {
        public UserDto User { get; set; }
        public UserAuthenticationDto UserAuthentication { get; set; }
    }
}
