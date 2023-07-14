namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Travels;

    public interface ITravelService
    {
        public Task<ICollection<TravelViewModel>> GetAllAsync();

        //public Task CreateAsync(TravelFormModel model);

        public Task<TravelDetailsViewModel?> GetDetailsByIdAsync(int id, string userId);

        //public Task EditAsync(int id, TravelFormModel model);

        public Task DeleteAsync(int id);
    }
}