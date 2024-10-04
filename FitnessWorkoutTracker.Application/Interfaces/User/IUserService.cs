using FitnessWorkoutTracker.Application.DTOs;
using FitnessWorkoutTracker.Domain.Entities.User;

namespace FitnessWorkoutTracker.Application.Interfaces.Users
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<bool> VerifyLoginAndPassword(LoginDto loginModel, CancellationToken cancellationToken);
    }
}
