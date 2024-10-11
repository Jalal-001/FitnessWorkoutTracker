using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Abstractions.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto loginModel);
        Task<bool> CheckUserExistAsync(UserDto user);
        Task<string> GenerateJsonWebToken(CancellationToken cancellationToken);
    }
}
