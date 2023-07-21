namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Destinations;

    public interface IDestinationService
    {
        public Task<ICollection<SelectDestinationViewModel>> GetAllForSelectionAsync();

        public Task<ICollection<DestinationViewModel>> GetAllAsync();

        public Task CreateAsync(DestinationFormModel model);

        public Task<DestinationDetailsViewModel?> GetByIdForDetailsAsync(int id);

        public Task<bool> DeleteAsync(int id);
    }
}