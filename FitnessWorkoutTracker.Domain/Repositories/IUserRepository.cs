using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository: IGeneralRepository<User,int>
    {
        Task<UserDto?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> VerifyLoginAndPasswordAsync(LoginDto login, CancellationToken cancellationToken);
    }
}
