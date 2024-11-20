using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            request.User.UserAuthentication = new Domain.Entities.Users.UserAuthentication
            {
                PassWordSalt = request.UserAuthentication.PassWordSalt,
                PasswordHash = _passwordHelper.HashPasswordAsync(request.UserAuthentication.PassWordSalt)
            };
            return await _userRepository.CreateAsync(request.User);
        }
    }
}
