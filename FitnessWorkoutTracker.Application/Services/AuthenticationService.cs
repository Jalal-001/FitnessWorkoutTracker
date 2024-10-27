using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<string> GenerateJsonWebToken(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> LoginAsync(LoginDto loginModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
