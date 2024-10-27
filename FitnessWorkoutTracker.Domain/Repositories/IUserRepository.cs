using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> VerifyLoginAndPasswordAsync(LoginDto login, CancellationToken cancellationToken);
    }
}
