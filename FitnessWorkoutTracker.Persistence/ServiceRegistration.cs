using FitnessWorkoutTracker.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

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
            return services;
        }
    }
}
