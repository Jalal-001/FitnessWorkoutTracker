using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, User>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            return user;
        }
    }
}
