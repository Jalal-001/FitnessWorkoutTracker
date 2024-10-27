using FitnessWorkoutTracker.Shared.DTOs;
using MediatR;

namespace FitnessWorkoutTracker.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQuery : IRequest<UserDto>
    {
        public string Email { get; set; }
    }
}
