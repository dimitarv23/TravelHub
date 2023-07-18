﻿namespace TravelHub.Core.Contracts
{
    using TravelHub.ViewModels.Destinations;
    using TravelHub.ViewModels.Travels;

    public interface IDestinationService
    {
        public Task<ICollection<TravelDestinationViewModel>> GetAllForTravelAsync();

        public Task<ICollection<DestinationViewModel>> GetAllAsync();

        //public Task CreateAsync(DestinationFormModel model);

        public Task<DestinationDetailsViewModel?> GetByIdForDetailsAsync(int id);

        //public Task<DestinationFormModel?> GetByIdForEditAsync(int id);

        //public Task EditAsync(int id, DestinationFormModel model);

        //public Task DeleteAsync(int id);
    }
}