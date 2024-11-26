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

        public async Task<int> CreateAsync(User user)
        {
            await _workoutDbContext.Users.AddAsync(user);
            return await _workoutDbContext.SaveChangesAsync();
        }

        public async Task<ICollection<User>> GetAllUserAsync(CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users
                .Include(ur => ur.UserRoles)
                .Include(ua => ua.UserAuthentication)
                .Include(us => us.UserSecurities)
                .ToListAsync(cancellationToken);
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users
                .Include(np => np.UserAuthentication)
                .Include(np => np.UserSecurities)
                .FirstOrDefaultAsync(x => x.Email == email, cancellationToken: cancellationToken);
        }
    }
}
