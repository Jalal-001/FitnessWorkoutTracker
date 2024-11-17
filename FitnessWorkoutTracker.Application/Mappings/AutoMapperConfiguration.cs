using AutoMapper;

namespace FitnessWorkoutTracker.Application.Mappings
{
    public class AutoMapperConfiguration
    {
        public MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile<UserProfile>();
            });
            return config;
        }
    }
}
