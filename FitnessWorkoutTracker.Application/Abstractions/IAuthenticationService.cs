using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Application.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto loginModel, CancellationToken cancellationToken);
        Task<bool> CheckUserExistAsync(UserDto user, CancellationToken cancellationToken);
        Task<string> GenerateJsonWebToken(CancellationToken cancellationToken);
    }
}