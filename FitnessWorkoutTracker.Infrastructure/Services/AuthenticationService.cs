using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Interfaces.Authentication;

namespace FitnessWorkoutTracker.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<string> LoginAsync(LoginDto loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserExistAsync(UserDto user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateJsonWebToken(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
