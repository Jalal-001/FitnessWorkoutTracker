using FitnessWorkoutTracker.Domain.Entities.Users;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository : IGeneralRepository<User, int>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<ICollection<User>> GetAllUserAsync(CancellationToken cancellationToken);
    }
}
