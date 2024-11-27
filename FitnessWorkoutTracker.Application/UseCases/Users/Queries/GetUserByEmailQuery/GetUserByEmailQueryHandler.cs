using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<GetUserByEmailQuery> _userValidator;


        public GetUserByEmailQueryHandler(IUserRepository userRepository, IValidator<GetUserByEmailQuery> userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            _userValidator.ValidateAndThrow(request);
            return await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken) ?? throw new Exception("User not found!");
        }
    }
}
