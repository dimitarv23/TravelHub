namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Travels;

    public interface IDestinationService
    {
        public Task<ICollection<TravelDestinationViewModel>> GetAllForTravelAsync();
    }
}