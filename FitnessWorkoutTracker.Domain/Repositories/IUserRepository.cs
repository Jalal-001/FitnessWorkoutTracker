using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> VerifyLoginAndPasswordAsync(LoginDto loginModel, CancellationToken cancellationToken);
    }
}
