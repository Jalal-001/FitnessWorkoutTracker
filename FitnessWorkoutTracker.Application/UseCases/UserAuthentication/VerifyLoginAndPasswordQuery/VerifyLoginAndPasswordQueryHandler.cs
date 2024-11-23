using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery
{
    public class VerifyLoginAndPasswordQueryHandler : IRequestHandler<VerifyLoginAndPasswordQuery, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHelper _passwordHelper;

        public VerifyLoginAndPasswordQueryHandler(IUserRepository userRepository, IPasswordHelper passwordHelper)
        {
            _userRepository = userRepository;
            _passwordHelper = passwordHelper;
        }

        public async Task<bool> Handle(VerifyLoginAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.LoginModel.Email, cancellationToken);
            if (user != null)
            {
                var verify = _passwordHelper.VerifyPasswordAsync(request.LoginModel.Password, user.UserAuthentication.PasswordHash);
                if (verify)
                    return true;
            }
            return false;
        }
    }
}
