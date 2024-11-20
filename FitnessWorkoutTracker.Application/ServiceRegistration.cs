using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessWorkoutTracker.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHelper, PasswordHelper>();
            return services;
        }
    }
}
