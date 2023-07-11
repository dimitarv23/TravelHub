namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Travels;

    public interface ITravelService
    {
        public Task<ICollection<TravelViewModel>> GetAllAsync();

        public Task<TravelDetailsViewModel?> GetDetailsByIdAsync(int id, string userId);

        public Task BookAsync(int travelId, string userId);

        public Task RemoveBookingAsync(int travelId, string userId);

    }
}