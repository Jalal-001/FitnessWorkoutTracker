using AutoMapper;
using FitnessWorkoutTracker.Application.Abstractions;
using FitnessWorkoutTracker.Application.Services;
using FitnessWorkoutTracker.Domain.Repositories;
using FitnessWorkoutTracker.Persistence.Contexts;
using FitnessWorkoutTracker.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Reflection;

namespace FitnessWorkoutTracker.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceservices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = string.Empty;

            services.AddDbContext<WorkoutDbContext>(option =>
            {
                if (!Debugger.IsAttached)
                    connectionString = Environment.GetEnvironmentVariable("DbFitnessTracker")!;
                else
                {
                    connectionString = configuration.GetConnectionString("DbFitnessTracker")!;
                    option.EnableSensitiveDataLogging();
                    option.EnableDetailedErrors();
                }
                option.UseSqlServer(configuration.GetConnectionString("DbFitnessTracker"));
            });
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load("FitnessWorkoutTracker.Application")));
            return services;
        }
    }
}
