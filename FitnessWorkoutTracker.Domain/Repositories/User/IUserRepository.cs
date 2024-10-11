using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Domain.Repositories.User
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> VerifyLoginAndPassword(LoginDto loginModel, CancellationToken cancellationToken);
    }
}
