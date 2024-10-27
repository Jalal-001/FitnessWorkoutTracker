using FitnessWorkoutTracker.Persistence.Contexts;
using FitnessWorkoutTracker.Shared.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FitnessWorkoutTracker.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly WorkoutDbContext _workoutDbContext;

        public GetUserByEmailQueryHandler(WorkoutDbContext workoutDbContext)
        {
            _workoutDbContext = workoutDbContext;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _workoutDbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (user == null)
                return new UserDto();

            return new UserDto
            {
                Name = user.Name,
                SurName = user.Surname,
                FullName = user.FullName,
                Email = user.Email,
                UpdatedAt = user.UpdatedAt,
                CreatedAt = user.CreatedAt,
                IsActive = user.IsActive
            };
        }
    }
}
