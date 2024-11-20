using FitnessWorkoutTracker.Application.Abstractions;

namespace FitnessWorkoutTracker.Application.Services
{
    public class PasswordHelper : IPasswordHelper
    {
        public string HashPasswordAsync(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        public bool VerifyPasswordAsync(string password,string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password,passwordHash);
        }
    }
}
