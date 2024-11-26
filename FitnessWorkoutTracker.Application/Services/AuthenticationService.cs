using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery;
using FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery;
using FitnessWorkoutTracker.Shared.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessWorkoutTracker.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;


        public AuthenticationService(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
            _mediator = mediator;
        }

        public string GenerateJsonWebToken(CancellationToken cancellationToken)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> LoginAsync(LoginModel loginModel, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserByEmailQuery(loginModel.Email));

            if (user != null)
            {
                var verified = await _mediator.Send(new VerifyLoginAndPasswordQuery(loginModel), cancellationToken);

                if (verified)
                {
                    var tokenString = GenerateJsonWebToken(cancellationToken);
                    return tokenString;
                }
            }
            return string.Empty;
        }
    }
}
