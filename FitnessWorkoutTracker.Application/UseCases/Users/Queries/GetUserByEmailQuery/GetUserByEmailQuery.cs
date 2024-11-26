using FitnessWorkoutTracker.Domain.Entities.Users;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQuery : IRequest<User>
    {
        public string Email { get; set; }

        public GetUserByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
