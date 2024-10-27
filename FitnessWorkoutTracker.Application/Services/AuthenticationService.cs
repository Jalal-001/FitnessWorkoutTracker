using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<bool> CheckUserExistAsync(UserDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

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
