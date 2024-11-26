using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Domain.Repositories;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetAllUserQuery
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ICollection<User>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ICollection<User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return _userRepository.GetAllUserAsync(cancellationToken);
        }
    }
}
