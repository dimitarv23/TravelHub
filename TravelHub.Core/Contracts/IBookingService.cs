namespace TravelHub.Core.Contracts
{
    public interface IBookingService
    {
        public Task CreateBookingAsync(int travelId, string userId);

        public Task RemoveBookingAsync(int travelId, string userId);
    }
}