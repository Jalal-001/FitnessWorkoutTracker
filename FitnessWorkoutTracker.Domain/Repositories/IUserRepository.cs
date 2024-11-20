using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.Models;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository: IGeneralRepository<User,int>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> VerifyLoginAndPasswordAsync(LoginModel login, CancellationToken cancellationToken);
    }
}
