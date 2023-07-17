namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Bookings;

    public interface IBookingService
    {
        public Task CreateBookingAsync(int travelId, string userId);

        public Task RemoveBookingAsync(int travelId, string userId);

        public Task<ICollection<BookingViewModel>> GetAllAsync();

        public Task<ICollection<BookingViewModel>> GetForUserAsync(string userId);
    }
}