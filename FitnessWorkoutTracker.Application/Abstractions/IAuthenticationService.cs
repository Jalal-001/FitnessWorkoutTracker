using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Application.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto loginModel, CancellationToken cancellationToken);
        string GenerateJsonWebToken(CancellationToken cancellationToken);
    }
}