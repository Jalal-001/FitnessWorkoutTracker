using FitnessWorkoutTracker.Domain.Entities.Users;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<User>
    {
        public User User { get; set; }

        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }
}
