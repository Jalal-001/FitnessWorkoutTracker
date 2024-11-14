using AutoMapper;
using AutoMapper.QueryableExtensions;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Persistence.Contexts;
using FitnessWorkoutTracker.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WorkoutDbContext _workoutDbContext;
        private readonly IMapper _mapper;

        public UserRepository(WorkoutDbContext workoutDbContext, IMapper mapper)
        {
            _workoutDbContext = workoutDbContext;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(UserDto entity)
        {
            await _workoutDbContext.AddAsync(entity);
            return await _workoutDbContext.SaveChangesAsync();
        }

        public async Task<UserDto?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return await _workoutDbContext.Users.ProjectTo<UserDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Email == email, cancellationToken: cancellationToken);
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
