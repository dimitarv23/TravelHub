﻿namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Travels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Text.RegularExpressions;

    public class TravelService : ITravelService
    {
        private readonly IRepository repository;

        public TravelService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<ICollection<TravelViewModel>> GetAllAsync()
        {
            return await this.repository.All<Travel>()
                .Select(t => new TravelViewModel()
                {
                    Id = t.Id,
                    Type = Regex.Replace(t.Type.ToString(), @"(?<!^)(?=[A-Z])", " "),
                    ImageUrl = t.Destination.ImageUrl,
                    Destination = $"{t.Destination.Place}, {t.Destination.Country}",
                    Price = t.Price,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    PlacesLeft = t.PlacesLeft
                }).ToListAsync();
        }

        public async Task<TravelDetailsViewModel?> GetDetailsByIdAsync(int id, string userId)
        {
            return await this.repository.All<Travel>()
                .Select(t => new TravelDetailsViewModel()
                {
                    Id = t.Id,
                    Description = t.Description,
                    Type = Regex.Replace(t.Type.ToString(), @"(?<!^)(?=[A-Z])", " "),
                    ImageUrl = t.Destination.ImageUrl,
                    Destination = $"{t.Destination.Place}, {t.Destination.Country}",
                    HotelName = t.Hotel == null ? null : t.Hotel.Name,
                    Price = t.Price,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    PlacesLeft = t.PlacesLeft,
                    MeetingLocation = t.MeetingLocation,
                    IsBooked = t.Bookings.Any(b => b.UserId == userId)
                }).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task BookAsync(int travelId, string userId)
        {
            Booking booking = new Booking()
            {
                TravelId = travelId,
                UserId = userId,
                BookDate = DateTime.UtcNow
            };

            await this.repository.AddAsync(booking);
            await this.repository.SaveChangesAsync();
        }

        public async Task RemoveBookingAsync(int travelId, string userId)
        {
            Booking booking = await this.repository.All<Booking>()
                .FirstAsync(b => b.UserId == userId && b.TravelId == travelId);

            this.repository.Delete(booking);
            await this.repository.SaveChangesAsync();
        }
    }
}