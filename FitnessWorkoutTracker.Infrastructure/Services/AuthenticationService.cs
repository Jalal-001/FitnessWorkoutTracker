﻿using FitnessWorkoutTracker.Abstractions.Authentication;
using FitnessWorkoutTracker.Application.Models;

namespace FitnessWorkoutTracker.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public Task<string> LoginAsync(LoginModel loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckUserExistAsync(UserModel user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GenerateJsonWebToken(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
