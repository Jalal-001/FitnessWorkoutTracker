using FluentValidation;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email cannot be null or empty!");
        }
    }
}
