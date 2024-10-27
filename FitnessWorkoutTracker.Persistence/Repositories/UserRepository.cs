using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Persistence.Contexts;
using FitnessWorkoutTracker.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

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
            return await _workoutDbContext.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<bool> VerifyLoginAndPasswordAsync(LoginDto login, CancellationToken cancellationToken)
        {
            return await _workoutDbContext.UserAuthentications
               .AnyAsync(ua =>
               (ua.UserName == login.UserName ||
               ua.Email == login.Email) &&
               ua.PassWordSalt == login.Password);
        }
    }
}
