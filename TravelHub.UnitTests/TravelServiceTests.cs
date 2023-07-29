namespace TravelHub.UnitTests
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;
    using TravelHub.Domain.Enums;
    using TravelHub.Domain.Models;
    using TravelHub.Infrastructure;
    using TravelHub.ViewModels.Travels;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    public class TravelServiceTests
    {
        private TravelHubContext dbContext;

        private IRepository repo = null!;

        private ITravelService travelService = null!;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TravelHubContext>()
                .UseInMemoryDatabase("TravelHub").Options;

            this.dbContext = new TravelHubContext(contextOptions);

            this.dbContext.Database.EnsureDeletedAsync();
            this.dbContext.Database.EnsureCreatedAsync();

            this.repo = new Repository(this.dbContext);
            this.travelService = new TravelService(this.repo);
        }

        [Test]
        public async Task TestCreate()
        {
            var destination = new Destination()
            {
                Country = "USA",
                Place = "New York City",
                Currency = "USD",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg"
            };

            await this.repo.AddAsync(destination);
            await this.repo.SaveChangesAsync();

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = destination.Id
            };

            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var travel = new TravelFormModel()
            {
                Type = eTravelType.BeachVacation,
                Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                Price = 780,
                DateFrom = new DateTime(2023, 7, 3),
                DateTo = new DateTime(2023, 7, 8),
                MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                MaxNumberOfPeople = 58,
                DestinationId = destination.Id,
                HotelId = hotel.Id
            };

            var initCount = this.repo.AllReadonly<Travel>().Count();
            await this.travelService.CreateAsync(travel);

            Assert.That(this.repo.AllReadonly<Travel>().Count(), Is.EqualTo(initCount + 1));
        }

        [Test]
        public async Task TestGetAll()
        {
            var travels = await this.travelService.GetAllAsync();
            var expectedCount = this.repo.AllReadonly<Travel>().Count();

            Assert.That(travels.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task TestGetByIdForDetails()
        {
            var destination = new Destination()
            {
                Country = "USA",
                Place = "New York City",
                Currency = "USD",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg"
            };

            await this.repo.AddAsync(destination);
            await this.repo.SaveChangesAsync();

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = destination.Id
            };

            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var travel = new Travel()
            {
                Type = eTravelType.BeachVacation,
                Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                Price = 780,
                DateFrom = new DateTime(2023, 7, 3),
                DateTo = new DateTime(2023, 7, 8),
                MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                MaxNumberOfPeople = 58,
                DestinationId = destination.Id,
                HotelId = hotel.Id
            };

            await this.repo.AddAsync(travel);
            await this.repo.SaveChangesAsync();

            var travelDetails = await this.travelService
                .GetByIdForDetailsAsync(travel.Id, "");

            Assert.That(travelDetails, Is.Not.Null);
            Assert.That(travelDetails.Type, Is.EqualTo("Beach Vacation"));
            Assert.That(travelDetails.ImageUrl, Is.EqualTo(destination.ImageUrl));
            Assert.That(travelDetails.Destination, Is.EqualTo("New York City, USA"));
            Assert.That(travelDetails.Price, Is.EqualTo(travel.Price));
            Assert.That(travelDetails.DateFrom, Is.EqualTo(travel.DateFrom));
            Assert.That(travelDetails.DateTo, Is.EqualTo(travel.DateTo));
            Assert.That(travelDetails.PlacesLeft, Is.EqualTo(travel.MaxNumberOfPeople));
            Assert.That(travelDetails.Description, Is.EqualTo(travel.Description));
            Assert.That(travelDetails.HotelName, Is.EqualTo(hotel.Name));
            Assert.That(travelDetails.MeetingLocation, Is.EqualTo(travel.MeetingLocation));
            Assert.That(travelDetails.IsBooked, Is.False);
            Assert.That(travelDetails.DestinationId, Is.EqualTo(destination.Id));
            Assert.That(travelDetails.HotelId, Is.EqualTo(hotel.Id));
        }

        [Test]
        public async Task TestGetByIdForDetailsWithInvalidId()
        {
            var travel = await this.travelService
                .GetByIdForDetailsAsync(-1, "");

            Assert.That(travel, Is.Null);
        }

        [Test]
        public async Task TestGetByIdForEdit()
        {
            var destination = new Destination()
            {
                Country = "USA",
                Place = "New York City",
                Currency = "USD",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg"
            };

            await this.repo.AddAsync(destination);
            await this.repo.SaveChangesAsync();

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = destination.Id
            };

            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var travel = new Travel()
            {
                Type = eTravelType.BeachVacation,
                Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                Price = 780,
                DateFrom = new DateTime(2023, 7, 3),
                DateTo = new DateTime(2023, 7, 8),
                MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                MaxNumberOfPeople = 58,
                DestinationId = destination.Id,
                HotelId = hotel.Id
            };

            await this.repo.AddAsync(travel);
            await this.repo.SaveChangesAsync();

            var travelForEdit = await this.travelService
                .GetByIdForEditAsync(travel.Id);

            Assert.That(travelForEdit, Is.Not.Null);
            Assert.That(travelForEdit.Type, Is.EqualTo(travel.Type));
            Assert.That(travelForEdit.Description, Is.EqualTo(travel.Description));
            Assert.That(travelForEdit.Price, Is.EqualTo(travel.Price));
            Assert.That(travelForEdit.DateFrom, Is.EqualTo(travel.DateFrom));
            Assert.That(travelForEdit.DateTo, Is.EqualTo(travel.DateTo));
            Assert.That(travelForEdit.MeetingLocation, Is.EqualTo(travel.MeetingLocation));
            Assert.That(travelForEdit.MaxNumberOfPeople, Is.EqualTo(travel.MaxNumberOfPeople));
            Assert.That(travelForEdit.DestinationId, Is.EqualTo(travel.DestinationId));
            Assert.That(travelForEdit.HotelId, Is.EqualTo(travel.HotelId));
        }

        [Test]
        public async Task TestGetByIdForEditWithInvalidId()
        {
            var travel = await this.travelService
                .GetByIdForEditAsync(-1);

            Assert.That(travel, Is.Null);
        }

        [Test]
        public async Task TestEdit()
        {
            var destination = new Destination()
            {
                Country = "USA",
                Place = "New York City",
                Currency = "USD",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg"
            };

            await this.repo.AddAsync(destination);
            await this.repo.SaveChangesAsync();

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = destination.Id
            };

            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var travel = new Travel()
            {
                Type = eTravelType.BeachVacation,
                Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023.",
                Price = 780,
                DateFrom = new DateTime(2023, 7, 3),
                DateTo = new DateTime(2023, 7, 8),
                MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                MaxNumberOfPeople = 58,
                DestinationId = destination.Id,
                HotelId = hotel.Id
            };

            await this.repo.AddAsync(travel);
            await this.repo.SaveChangesAsync();

            var travelToEdit = new TravelFormModel()
            {
                Type = eTravelType.ExoticVacation,
                Description = travel.Description + " Come and party with us!",
                Price = 820,
                DateFrom = travel.DateFrom,
                DateTo = travel.DateTo,
                MeetingLocation = "Hotel 'Ezerets', Blagoevgrad",
                MaxNumberOfPeople = travel.MaxNumberOfPeople,
                DestinationId = travel.DestinationId,
                HotelId = travel.HotelId ?? 0
            };

            await this.travelService.EditAsync(travel.Id, travelToEdit);
            var editedTravel = await this.repo.GetByIdAsync<Travel>(travel.Id);

            Assert.That(editedTravel.Type, Is.EqualTo(travelToEdit.Type));
            Assert.That(editedTravel.Price, Is.EqualTo(travelToEdit.Price));
            Assert.That(editedTravel.MeetingLocation, Is.EqualTo(travelToEdit.MeetingLocation));
            Assert.That(editedTravel.Price, Is.EqualTo(travelToEdit.Price));
        }

        [Test]
        public async Task TestDelete()
        {
            var destination = new Destination()
            {
                Country = "USA",
                Place = "New York City",
                Currency = "USD",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg"
            };

            await this.repo.AddAsync(destination);
            await this.repo.SaveChangesAsync();

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = destination.Id
            };

            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var travel = new Travel()
            {
                Type = eTravelType.BeachVacation,
                Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                Price = 780,
                DateFrom = new DateTime(2023, 7, 3),
                DateTo = new DateTime(2023, 7, 8),
                MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                MaxNumberOfPeople = 58,
                DestinationId = destination.Id,
                HotelId = hotel.Id
            };

            await this.repo.AddAsync(travel);
            await this.repo.SaveChangesAsync();

            var initCount = this.repo.AllReadonly<Travel>().Count();
            bool isDeleted = await this.travelService.DeleteAsync(travel.Id);

            Assert.That(isDeleted, Is.True);
            Assert.That(this.repo.AllReadonly<Travel>().Count(), Is.EqualTo(initCount - 1));
        }

        [Test]
        public async Task TestDeleteNonExisting()
        {
            var initCount = this.repo.AllReadonly<Travel>().Count();
            bool isDeleted = await this.travelService.DeleteAsync(-1);

            Assert.That(isDeleted, Is.False);
            Assert.That(this.repo.AllReadonly<Travel>().Count(), Is.EqualTo(initCount));
        }

        [TearDown]
        public async Task TearDown()
        {
            await this.dbContext.DisposeAsync();
        }
    }
}