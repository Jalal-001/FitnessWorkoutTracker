using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.CreateAsync(request.User);
        }
    }
}
