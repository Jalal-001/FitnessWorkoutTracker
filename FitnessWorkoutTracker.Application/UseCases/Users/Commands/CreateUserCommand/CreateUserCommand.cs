using FitnessWorkoutTracker.Domain.Entities.Users;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<int>
    {
        public User User { get; set; }
        public Domain.Entities.Users.UserAuthentication UserAuthentication { get; set; }


        public CreateUserCommand(User user, Domain.Entities.Users.UserAuthentication userAuthentication)
        {
            User = user;
            UserAuthentication = userAuthentication;
        }
    }
}
