using FitnessWorkoutTracker.Shared.Models;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery
{
    public class VerifyLoginAndPasswordQuery : IRequest<bool>
    {
        public LoginModel LoginModel { get; set; }

        public VerifyLoginAndPasswordQuery(LoginModel loginModel)
        {
            LoginModel = loginModel;
        }
    }
}
