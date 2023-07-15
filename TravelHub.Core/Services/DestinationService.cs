namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
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

        public async Task<ICollection<TravelDestinationViewModel>> GetAllForTravelAsync()
        {
            return await this.repository.All<Destination>()
                .Select(d => new TravelDestinationViewModel()
                {
                    Id = d.Id,
                    Country = d.Country,
                    Place = d.Place
                }).ToListAsync();
        }
    }
}