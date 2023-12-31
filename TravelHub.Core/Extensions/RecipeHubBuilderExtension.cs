﻿namespace TravelHub.Core.Extensions
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class TravelHubBuilderExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<ITravelService, TravelService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IDestinationService, DestinationService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IReviewService, ReviewService>();

            return services;
        }
    }
}