namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Travels;

    public interface IHotelService
    {
        public Task<ICollection<TravelHotelViewModel>> GetAllForTravelAsync();
    }
}