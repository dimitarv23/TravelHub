namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Travels;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TravelHub.ViewModels.Hotels;

    public class HotelService : IHotelService
    {
        private readonly IRepository repository;

        public HotelService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public Task CreateAsync(HotelFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<HotelViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<TravelHotelViewModel>> GetAllForTravelAsync()
        {
            return await this.repository.All<Hotel>()
                .Select(h => new TravelHotelViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    FoodService = h.FoodService,
                    Rating = h.Rating,
                    Destination = $"{h.Destination.Place}, {h.Destination.Country}"
                }).ToListAsync();
        }

        public Task<HotelDetailsViewModel?> GetByIdForDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HotelFormModel?> GetByIdForEditAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, HotelFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}