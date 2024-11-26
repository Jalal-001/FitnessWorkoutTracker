using FitnessWorkoutTracker.Domain.Entities.Users;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetAllUserQuery
{
    public class GetAllUserQuery : IRequest<ICollection<User>>
    {
    }
}
