using MediatR;

namespace FitnessWorkoutTracker.Application.UseCases.UserAuthentication.RemoveRefreshTokenCommand
{
    public class RemoveRefreshTokenCommand : IRequest<int>
    {
        public int UserId { get; set; }

        public RemoveRefreshTokenCommand(int userId)
        {
            UserId = userId;
        }
    }
}
