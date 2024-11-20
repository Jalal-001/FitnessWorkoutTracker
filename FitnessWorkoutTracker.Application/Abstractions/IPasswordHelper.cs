namespace FitnessWorkoutTracker.Application.Abstractions
{
    public interface IPasswordHelper
    {
        string HashPasswordAsync(string password);
        bool VerifyPasswordAsync(string password, string passwordHash);
    }
}
