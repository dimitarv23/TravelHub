namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Travels;

    public interface ITravelService
    {
        public Task<ICollection<TravelViewModel>> GetAllAsync();

        public Task CreateAsync(TravelFormModel model);

        public Task<TravelDetailsViewModel?> GetByIdForDetailsAsync(int id, string userId);

        public Task<TravelFormModel?> GetByIdForEditAsync(int id);

        public Task EditAsync(int id, TravelFormModel model);

        public Task<bool> DeleteAsync(int id);
    }
}