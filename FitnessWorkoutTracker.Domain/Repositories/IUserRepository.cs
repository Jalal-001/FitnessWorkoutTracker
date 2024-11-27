using FitnessWorkoutTracker.Domain.Entities.Users;

namespace FitnessWorkoutTracker.Domain.Repositories
{
    public interface IUserRepository : IGeneralRepository<User, int>
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        //Task<ICollection<User>> GetAllUserAsync(CancellationToken cancellationToken);
        //Task<User?> GetUserByIdAsync(int id, CancellationToken cancellationToken);
        //Task<User> UpdateUserAsync(User user, CancellationToken cancellationToken);
    }
}
