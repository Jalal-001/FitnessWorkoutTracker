using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.Services;
using FitnessWorkoutTracker.Application.Utilities;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FitnessWorkoutTracker.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHelper, PasswordHelper>();
            services.AddTransient<TokenUtils>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
