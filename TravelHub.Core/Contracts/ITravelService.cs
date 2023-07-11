namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Travels;

    public interface ITravelService
    {
        public Task<ICollection<TravelViewModel>> GetAllTravelsAsync();

        public Task<TravelDetailsViewModel?> GetDetailsByIdAsync(int id);

    }
}