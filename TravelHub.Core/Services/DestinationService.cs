namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Destinations;
    using TravelHub.ViewModels.Travels;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class DestinationService : IDestinationService
    {
        private readonly IRepository repository;

        public DestinationService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task CreateAsync(DestinationFormModel model)
        {
            Destination destinationToAdd = new Destination()
            {
                Country = model.Country,
                Place = model.Place,
                Currency = model.Currency,
                ImageUrl = model.ImageUrl
            };

            await this.repository.AddAsync(destinationToAdd);
            await this.repository.SaveChangesAsync();
        }

        public async Task<ICollection<DestinationViewModel>> GetAllAsync()
        {
            return await this.repository.All<Destination>()
                .Select(d => new DestinationViewModel()
                {
                    Id = d.Id,
                    Country = d.Country,
                    Place = d.Place,
                    ImageUrl = d.ImageUrl
                }).ToListAsync();
        }

        public async Task<ICollection<TravelDestinationViewModel>> GetAllForTravelAsync()
        {
            return await this.repository.All<Destination>()
                .Include(d => d.Hotels)
                .Select(d => new TravelDestinationViewModel()
                {
                    Id = d.Id,
                    Country = d.Country,
                    Place = d.Place,
                    Hotels = d.Hotels
                        .Select(h => new TravelHotelViewModel()
                        {
                            Id = h.Id,
                            Name = h.Name,
                            FoodService = h.FoodService,
                            Rating = h.Rating
                        }).ToList()
                }).ToListAsync();
        }

        public async Task<DestinationDetailsViewModel?> GetByIdForDetailsAsync(int id)
        {
            return await this.repository.All<Destination>()
                .Select(d => new DestinationDetailsViewModel()
                {
                    Id = d.Id,
                    Country = d.Country,
                    Place = d.Place,
                    ImageUrl = d.ImageUrl,
                    Currency = d.Currency,
                    Hotels = d.Hotels
                        .Select(h => new DestinationHotelViewModel()
                        {
                            Id = h.Id,
                            Name = h.Name,
                            ImageUrl = h.ImageUrl
                        }).ToList()
                }).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            await this.repository.DeleteAsync<Destination>(id);
            await this.repository.SaveChangesAsync();
        }
    }
}