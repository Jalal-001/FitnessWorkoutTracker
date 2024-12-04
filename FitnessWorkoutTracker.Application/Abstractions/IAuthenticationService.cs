using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.Models;

namespace FitnessWorkoutTracker.Application.Abstractions
{
    public interface IAuthenticationService
    {
        Task<TokenResponseModel> LoginAsync(LoginModel loginModel, CancellationToken cancellationToken);
        Task<(TokenResponseModel? tokenResponse, User? user)> ValidateRefreshTokenAsync(int userId, CancellationToken cancellationToken);
        Task<int> LogOutAsync(int userId, CancellationToken cancellationToken);
    }
}