using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.UseCases.UserAuthentication.RemoveRefreshTokenCommand;
using FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery;
using FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery;
using FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByIdQuery;
using FitnessWorkoutTracker.Application.Utilities;
using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Shared.Models;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace FitnessWorkoutTracker.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly TokenUtils _tokenUtils;
        private readonly IUserRepository _userRepository;


        public AuthenticationService(IConfiguration configuration, IMediator mediator, TokenUtils tokenUtils, IUserRepository userRepository)
        {
            _configuration = configuration;
            _mediator = mediator;
            _tokenUtils = tokenUtils;
            _userRepository = userRepository;
        }

        public async Task<TokenResponseModel> LoginAsync(LoginModel loginModel, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByEmailQuery(loginModel.Email));

            if (user != null)
            {
                var verified = await _mediator.Send(new VerifyLoginAndPasswordQuery(loginModel), cancellationToken);

                if (verified)
                {
                    var accessToken = _tokenUtils.GenerateAccessToken(user);
                    var refreshToken = _tokenUtils.GenerateRefreshToken();
                    await _userRepository.AddRefreshTokenAsync(user, refreshToken, cancellationToken);
                    return new TokenResponseModel(accessToken.token, refreshToken, accessToken.expireDate);
                }
            }
            return new TokenResponseModel();
        }

        public async Task<int> LogOutAsync(int userId, CancellationToken cancellationToken)
        {
            //var user = await _mediator.Send(new GetUserByIdQuery(userId));
            return await _mediator.Send(new RemoveRefreshTokenCommand(userId));
        }

        public async Task<(TokenResponseModel? tokenResponse, User? user)> ValidateRefreshTokenAsync(int userId, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(userId));
            if (!string.IsNullOrWhiteSpace(user?.UserAuthentication?.RefreshToken))
            {
                var newAccessToken = _tokenUtils.GenerateAccessToken(user);
                return (new TokenResponseModel(newAccessToken.token, user.UserAuthentication.RefreshToken, newAccessToken.expireDate), user);
            }
            return (null, null);
        }
    }
}
