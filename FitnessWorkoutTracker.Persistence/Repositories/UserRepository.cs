using AutoMapper;
using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkoutDbContext _workoutDbContext;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IMapper _mapper;

        public UserRepository(WorkoutDbContext workoutDbContext, IPasswordHelper passwordHelper, IMapper mapper)
        {
            _workoutDbContext = workoutDbContext;
            _passwordHelper = passwordHelper;
            _mapper = mapper;
        }

        public async Task<User> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users
                .Include(u => u.UserAuthentication)
                .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users
                .Include(np => np.UserAuthentication)
                .Include(np => np.UserSecurities)
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken: cancellationToken);
        }

        public async Task<ICollection<User>?> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<User> UpdateAsync(User value, CancellationToken cancellationToken)
        {
            _workoutDbContext.Update(value);
            await _workoutDbContext.SaveChangesAsync(cancellationToken);
            return value;
        }

        public async Task<int> CreateAsync(User user, CancellationToken cancellationToken)
        {
            await _workoutDbContext.Users.AddAsync(user);
            return await _workoutDbContext.SaveChangesAsync();
        }

        public async Task<int> AddRefreshTokenAsync(User user, string refreshToken, CancellationToken cancellationToken)
        {
            user.UserAuthentication.RefreshToken = refreshToken;
            return await _workoutDbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<int> RemoveRefreshTokenAsync(int userId, CancellationToken cancellationToken)
        {
            var userAuth = await _workoutDbContext.UserAuthentications.FirstOrDefaultAsync(ua => ua.UserId == userId);
            userAuth.RefreshToken = string.Empty;
            return await _workoutDbContext.SaveChangesAsync();
        }
    }
}
