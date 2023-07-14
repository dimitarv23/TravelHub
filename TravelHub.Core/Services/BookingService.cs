namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
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