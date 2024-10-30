using FitnessWorkoutTracker.Shared.DTOs;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<int>
    {
        public UserDto User { get; set; }

        public CreateUserCommand(UserDto user)
        {
            User = user;
        }
    }
}
