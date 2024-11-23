using FitnessWorkoutTracker.Shared.Models;

namespace FitnessWorkoutTracker.Application.Abstractions
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginModel loginModel, CancellationToken cancellationToken);
        string GenerateJsonWebToken(CancellationToken cancellationToken);
    }
}