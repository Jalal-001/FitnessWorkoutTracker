﻿using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Shared.DTOs;
using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.Users.Queries.GetUserByEmailQuery
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDto>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email, cancellationToken);

            if (user == null)
                return new UserDto();

            return user;
        }
    }
}
