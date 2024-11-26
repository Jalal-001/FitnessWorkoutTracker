using FluentValidation;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.VerifyLoginAndPasswordQuery
{
    public class VerifyLoginAndPasswordValidator : AbstractValidator<VerifyLoginAndPasswordQuery>
    {
        public VerifyLoginAndPasswordValidator()
        {
            RuleFor(l => l.LoginModel.Email)
                .NotEmpty()
                .WithMessage("Email cannot be null or empty!");

            RuleFor(l => l.LoginModel.Password)
                .NotEmpty()
                .WithMessage("Password cannot be null or empty!");
        }
    }
}
