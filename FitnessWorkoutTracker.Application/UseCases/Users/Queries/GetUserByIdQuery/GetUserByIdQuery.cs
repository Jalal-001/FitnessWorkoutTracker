using FitnessWorkoutTracker.Domain.Entities.Users;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByIdQuery
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
