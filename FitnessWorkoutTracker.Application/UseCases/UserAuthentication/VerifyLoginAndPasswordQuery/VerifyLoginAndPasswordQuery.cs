using FitnessWorkoutTracker.Shared.DTOs;
using FitnessWorkoutTracker.Shared.Models;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery
{
    public class VerifyLoginAndPasswordQuery : IRequest<bool>
    {
        public LoginModel Login { get; set; }

        public VerifyLoginAndPasswordQuery(LoginModel login)
        {
            Login = login;
        }
    }
}
