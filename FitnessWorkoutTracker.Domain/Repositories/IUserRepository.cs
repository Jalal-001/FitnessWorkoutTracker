using FitnessWorkoutTracker.Domain.Entities.Users;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository : IGeneralRepository<User, int>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<int> AddRefreshTokenAsync(User user, string refreshToken, CancellationToken cancellationToken);
        Task<int> RemoveRefreshTokenAsync(int userId, CancellationToken cancellationToken);
    }
}
