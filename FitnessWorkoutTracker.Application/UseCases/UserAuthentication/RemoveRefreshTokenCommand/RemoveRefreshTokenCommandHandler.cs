using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.RemoveRefreshTokenCommand
{
    public class RemoveRefreshTokenCommandHandler : IRequestHandler<RemoveRefreshTokenCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public RemoveRefreshTokenCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<int> Handle(RemoveRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.RemoveRefreshTokenAsync(request.UserId, cancellationToken);
        }
    }
}
