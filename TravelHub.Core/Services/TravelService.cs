namespace TravelHub.Core.Services
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Domain.Models;
    using TravelHub.ViewModels.Travels;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class TravelService : ITravelService
    {
        private readonly IRepository repository;

        public TravelService(IRepository _repository)
        {
            this.repository = _repository;
        }

        public async Task<ICollection<TravelViewModel>> GetAllAsync()
        {
            return await this.repository.All<Travel>()
                .Include(t => t.Bookings)
                .Select(t => new TravelViewModel()
                {
                    Id = t.Id,
                    Type = Regex.Replace(t.Type.ToString(), @"(?<!^)(?=[A-Z])", " "),
                    ImageUrl = t.Destination.ImageUrl,
                    Destination = $"{t.Destination.Place}, {t.Destination.Country}",
                    Price = t.Price,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    PlacesLeft = t.PlacesLeft
                }).ToListAsync();
        }

        public async Task<TravelDetailsViewModel?> GetByIdForDetailsAsync(int id, string userId)
        {
            return await this.repository.All<Travel>()
                .Include(t => t.Bookings)
                .Select(t => new TravelDetailsViewModel()
                {
                    Id = t.Id,
                    Description = t.Description,
                    Type = Regex.Replace(t.Type.ToString(), @"(?<!^)(?=[A-Z])", " "),
                    ImageUrl = t.Destination.ImageUrl,
                    Destination = $"{t.Destination.Place}, {t.Destination.Country}",
                    HotelName = t.Hotel == null ? null : t.Hotel.Name,
                    Price = t.Price,
                    DateFrom = t.DateFrom,
                    DateTo = t.DateTo,
                    PlacesLeft = t.PlacesLeft,
                    MeetingLocation = t.MeetingLocation,
                    IsBooked = t.Bookings.Any(b => b.UserId == userId),
                    DestinationId = t.DestinationId,
                    HotelId = t.HotelId
                }).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateAsync(TravelFormModel model)
        {
            Travel travelToAdd = new Travel()
            {
                Type = model.Type,
                Description = model.Description,
                Price = model.Price,
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                MeetingLocation = model.MeetingLocation,
                MaxNumberOfPeople = model.MaxNumberOfPeople,
                DestinationId = model.DestinationId,
                HotelId = model.HotelId == 0 ? null : model.HotelId
            };

            await this.repository.AddAsync(travelToAdd);
            await this.repository.SaveChangesAsync();
        }

        public async Task<TravelFormModel?> GetByIdForEditAsync(int id)
        {
            var travel = await this.repository.GetByIdAsync<Travel>(id);

            if (travel == null)
            {
                return null;
            }

            return new TravelFormModel()
            {
                Description = travel.Description,
                Type = travel.Type,
                Price = travel.Price,
                DateFrom = travel.DateFrom,
                DateTo = travel.DateTo,
                MeetingLocation = travel.MeetingLocation,
                MaxNumberOfPeople = travel.MaxNumberOfPeople,
                DestinationId = travel.DestinationId,
                HotelId = travel.HotelId ?? 0
            };
        }

        public async Task EditAsync(int id, TravelFormModel model)
        {
            var travelToEdit = await this.repository.GetByIdAsync<Travel>(id);

            if (travelToEdit == null)
            {
                return;
            }

            travelToEdit.Description = model.Description;
            travelToEdit.Type = model.Type;
            travelToEdit.Price = model.Price;
            travelToEdit.DateFrom = model.DateFrom;
            travelToEdit.DateTo = model.DateTo;
            travelToEdit.MeetingLocation = model.MeetingLocation;
            travelToEdit.MaxNumberOfPeople = model.MaxNumberOfPeople;
            travelToEdit.DestinationId = model.DestinationId;
            travelToEdit.HotelId = model.HotelId == 0 ? null : model.HotelId;

            this.repository.Update(travelToEdit);
            await this.repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var travelToDelete = await this.repository
                .GetByIdAsync<Travel>(id);

            if (travelToDelete == null)
            {
                return false;
            }

            await this.repository.DeleteAsync<Travel>(id);
            await this.repository.SaveChangesAsync();
            return true;
        }
    }
}