namespace TravelHub.Core.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;

    public static class TravelHubBuilderExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<ITravelService, TravelService>();

            return services;
        }
    }
}