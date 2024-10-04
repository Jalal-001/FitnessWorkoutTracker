using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Domain.Entities.User;

namespace FitnessWorkoutTracker.Application.Interfaces.Authentication
{
    public interface IAuthenticationService
    {
        Task<string> LoginAsync(LoginDto loginModel);
        Task<bool> CheckUserExistAsync(UserDto user);
        Task<string> GenerateJsonWebToken(CancellationToken cancellationToken);
    }
}
