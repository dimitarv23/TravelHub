namespace TravelHub.Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using TravelHub.Core.Repositories;

    public static class TravelHubBuilderExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}