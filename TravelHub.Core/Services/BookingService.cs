namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Bookings;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    public class BookingService : IBookingService
    {
        private readonly IRepository repository;

        public BookingService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task CreateBookingAsync(int travelId, string userId)
        {
            var travel = await this.repository.GetByIdAsync<Travel>(travelId);

            bool doesUserExist = await this.repository.All<User>()
                .AnyAsync(u => u.Id == userId);

            bool doesBookingExist = await this.repository.All<Booking>()
                .AnyAsync(b => b.TravelId == travelId
                    && b.UserId == userId);

            if (travel == null || travel?.PlacesLeft <= 0 || !doesUserExist || doesBookingExist)
            {
                return;
            }

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
            var booking = await this.repository.All<Booking>()
                .FirstOrDefaultAsync(b => b.UserId == userId && b.TravelId == travelId);

            if (booking == null)
            {
                return;
            }

            this.repository.Delete(booking);
            await this.repository.SaveChangesAsync();
        }

        public async Task<ICollection<BookingViewModel>> GetAllAsync()
        {
            return await this.repository.All<Booking>()
                .Select(b => new BookingViewModel()
                {
                    Destination = $"{b.Travel.Destination.Place}, {b.Travel.Destination.Country}",
                    ImageUrl = b.Travel.Destination.ImageUrl,
                    Price = b.Travel.Price,
                    Owner = $"{b.User.FirstName} {b.User.LastName} ({b.User.UserName})",
                    DateFrom = b.Travel.DateFrom,
                    DateTo = b.Travel.DateTo,
                    BookDate = b.BookDate,
                    TravelId = b.TravelId,
                    UserId = b.UserId
                }).ToListAsync();
        }

        public async Task<ICollection<BookingViewModel>> GetForUserAsync(string userId)
        {
            return await this.repository.All<Booking>()
                .Where(b => b.UserId == userId)
                .Select(b => new BookingViewModel()
                {
                    Destination = $"{b.Travel.Destination.Place}, {b.Travel.Destination.Country}",
                    ImageUrl = b.Travel.Destination.ImageUrl,
                    Price = b.Travel.Price,
                    Owner = $"{b.User.FirstName} {b.User.LastName} ({b.User.UserName})",
                    DateFrom = b.Travel.DateFrom,
                    DateTo = b.Travel.DateTo,
                    BookDate = b.BookDate,
                    TravelId = b.TravelId,
                    UserId = b.UserId
                }).ToListAsync();
        }
    }
}