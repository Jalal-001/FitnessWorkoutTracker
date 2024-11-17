using AutoMapper;
using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.DTOs;

namespace FitnessWorkoutTracker.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
