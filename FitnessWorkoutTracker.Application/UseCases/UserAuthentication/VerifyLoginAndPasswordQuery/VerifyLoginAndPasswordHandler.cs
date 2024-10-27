using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery
{
    public class VerifyLoginAndPasswordHandler : IRequestHandler<VerifyLoginAndPasswordQuery, bool>
    {
        private readonly IUserRepository _userRepository;

        public VerifyLoginAndPasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(VerifyLoginAndPasswordQuery request, CancellationToken cancellationToken)
        {
            if (request.Login == null)
                return false;

            return await _userRepository.VerifyLoginAndPasswordAsync(request.Login, cancellationToken);
        }
    }
}
