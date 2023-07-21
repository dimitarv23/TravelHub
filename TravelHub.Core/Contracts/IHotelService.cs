namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Hotels;
    using TravelHub.ViewModels.Travels;

    public interface IHotelService
    {
        public Task<ICollection<HotelViewModel>> GetAllAsync();

        public Task<ICollection<TravelHotelViewModel>> GetAllForTravelAsync();

        public Task CreateAsync(HotelFormModel model);

        public Task<HotelDetailsViewModel?> GetByIdForDetailsAsync(int id);

        public Task<HotelFormModel?> GetByIdForEditAsync(int id);

        public Task EditAsync(int id, HotelFormModel model);

        public Task<bool> DeleteAsync(int id);
    }
}