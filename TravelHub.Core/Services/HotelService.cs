namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Hotels;
    using TravelHub.ViewModels.Reviews;
    using TravelHub.ViewModels.Travels;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class HotelService : IHotelService
    {
        private readonly IRepository repository;

        public HotelService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task CreateAsync(HotelFormModel model)
        {
            bool doesDestinationExist = await this.repository.All<Destination>()
                .AnyAsync(d => d.Id == model.DestinationId);

            if (!doesDestinationExist)
            {
                return;
            }

            Hotel hotelToAdd = new Hotel()
            {
                Name = model.Name,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                FoodService = model.FoodService,
                HasPool = model.HasPool,
                HasSpa = model.HasSpa,
                DestinationId = model.DestinationId
            };

            await this.repository.AddAsync(hotelToAdd);
            await this.repository.SaveChangesAsync();
        }

        public async Task<ICollection<HotelViewModel>> GetAllAsync()
        {
            return await this.repository.All<Hotel>()
                .Select(h => new HotelViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    ImageUrl = h.ImageUrl,
                    Destination = $"{h.Destination.Place}, {h.Destination.Country}",
                    Rating = h.Rating
                }).ToListAsync();
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

        public async Task<HotelDetailsViewModel?> GetByIdForDetailsAsync(int id)
        {
            return await this.repository.All<Hotel>()
                .Select(h => new HotelDetailsViewModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    ImageUrl = h.ImageUrl,
                    Destination = $"{h.Destination.Place}, {h.Destination.Country}",
                    Rating = h.Rating,
                    FoodService = Regex.Replace(h.FoodService.ToString(), @"(?<!^)(?=[A-Z])", " "),
                    HasPool = h.HasPool,
                    HasSpa = h.HasSpa,
                    DestinationId = h.DestinationId,
                    Reviews = h.Reviews
                    .Select(r => new ReviewViewModel()
                    {
                        Id = r.Id,
                        Comment = r.Comment,
                        AuthorUsername = r.User.UserName,
                        AuthorId = r.UserId,
                        DateAdded = r.DateAdded
                    })
                    .OrderByDescending(r => r.DateAdded)
                    .ToList()
                }).FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<HotelFormModel?> GetByIdForEditAsync(int id)
        {
            var hotel = await this.repository.GetByIdAsync<Hotel>(id);

            if (hotel == null)
            {
                return null;
            }

            return new HotelFormModel()
            {
                Name = hotel.Name,
                ImageUrl = hotel.ImageUrl,
                Rating = hotel.Rating,
                FoodService = hotel.FoodService,
                HasPool = hotel.HasPool,
                HasSpa = hotel.HasSpa,
                DestinationId = hotel.DestinationId
            };
        }
        
        public async Task EditAsync(int id, HotelFormModel model)
        {
            var hotelToEdit = await this.repository.GetByIdAsync<Hotel>(id);

            if (hotelToEdit == null)
            {
                return;
            }

            hotelToEdit.Name = model.Name;
            hotelToEdit.ImageUrl = model.ImageUrl;
            hotelToEdit.Rating = model.Rating;
            hotelToEdit.FoodService = model.FoodService;
            hotelToEdit.HasPool = model.HasPool;
            hotelToEdit.HasSpa = model.HasSpa;
            hotelToEdit.DestinationId = model.DestinationId;

            this.repository.Update(hotelToEdit);
            await this.repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var hotelToDelete = await this.repository
                .GetByIdAsync<Hotel>(id);

            if (hotelToDelete == null)
            {
                return false;
            }

            await this.repository.DeleteAsync<Hotel>(id);
            await this.repository.SaveChangesAsync();
            return true;
        }
    }
}