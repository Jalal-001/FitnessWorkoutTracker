using AutoMapper;
using FitnessWorkoutTracker.Domain.Entities.Users;
using FitnessWorkoutTracker.Shared.DTOs.User;
using FitnessWorkoutTracker.Shared.Models;

namespace FitnessWorkoutTracker.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserAuthenticationDto, UserAuthentication>().ReverseMap();
        }
    }
}
