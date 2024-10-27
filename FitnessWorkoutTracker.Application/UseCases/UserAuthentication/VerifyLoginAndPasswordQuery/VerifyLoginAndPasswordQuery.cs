using FitnessWorkoutTracker.Shared.DTOs;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery
{
    public class VerifyLoginAndPasswordQuery : IRequest<bool>
    {
        public LoginDto Login { get; set; }

        public VerifyLoginAndPasswordQuery(LoginDto login)
        {
            Login = login;
        }
    }
}
