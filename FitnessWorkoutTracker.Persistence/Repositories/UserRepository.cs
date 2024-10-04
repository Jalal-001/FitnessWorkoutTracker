using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Application.Interfaces.Users;
using FitnessWorkoutTracker.Domain.Entities.User;
using FitnessWorkoutTracker.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Persistence.Repositories
{
    public class UserRepository : IUserService
    {
        private readonly WorkoutDbContext _workoutDbContext;

        public UserRepository(WorkoutDbContext workoutDbContext)
        {
            _workoutDbContext = workoutDbContext;
        }

        public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public Task<bool> VerifyLoginAndPassword(LoginDto loginModel, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

            //cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
