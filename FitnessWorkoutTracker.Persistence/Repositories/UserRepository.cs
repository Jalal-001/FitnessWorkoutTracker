using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Persistence.Contexts;
using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkoutDbContext _workoutDbContext;

        public UserRepository(WorkoutDbContext workoutDbContext)
        {
            _workoutDbContext = workoutDbContext;
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //return await _workoutDbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public Task<bool> VerifyLoginAndPasswordAsync(LoginDto loginModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            //cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
