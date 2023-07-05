namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Travels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class TravelService : ITravelService
    {
        private readonly IRepository repository;

        public TravelService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<ICollection<TravelViewModel>> GetAllTravelsAsync()
        {
            return await this.repository.All<Travel>()
                .Select(t => new TravelViewModel()
                {
                    Type = t.Type,
                    ImageUrl = t.Destination.ImageUrl,
                    Destination = $"{t.Destination.Place}, {t.Destination.Country}",
                    Price = t.Price,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    PlacesLeft = t.PlacesLeft
                }).ToListAsync();
        }
    }
}