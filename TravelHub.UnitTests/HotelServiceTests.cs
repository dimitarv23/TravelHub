namespace TravelHub.UnitTests
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;
    using TravelHub.Domain.Enums;
    using TravelHub.Domain.Models;
    using TravelHub.Infrastructure;
    using TravelHub.ViewModels.Hotels;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    public class HotelServiceTests
    {
        private TravelHubContext dbContext;

        private IRepository repo = null!;

        private IHotelService hotelService = null!;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TravelHubContext>()
                .UseInMemoryDatabase("TravelHub").Options;

            this.dbContext = new TravelHubContext(contextOptions);

            this.dbContext.Database.EnsureDeletedAsync();
            this.dbContext.Database.EnsureCreatedAsync();

            this.repo = new Repository(this.dbContext);
            this.hotelService = new HotelService(this.repo);
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

            var hotel = new HotelFormModel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = destination.Id
            };

            var initCount = this.repo.AllReadonly<Hotel>().Count();
            await this.hotelService.CreateAsync(hotel);

            Assert.That(this.repo.AllReadonly<Hotel>().Count(), Is.EqualTo(initCount + 1));
        }

        [Test]
        public async Task TestCreateWithInvalidDestination()
        {
            var hotel = new HotelFormModel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = -1
            };

            var initCount = this.repo.AllReadonly<Hotel>().Count();
            await this.hotelService.CreateAsync(hotel);

            Assert.That(this.repo.AllReadonly<Hotel>().Count(), Is.EqualTo(initCount));
        }

        [Test]
        public async Task TestGetAll()
        {
            var hotels = await this.hotelService.GetAllAsync();
            var expectedCount = this.repo.AllReadonly<Hotel>().Count();

            Assert.That(hotels.Count, Is.EqualTo(expectedCount));

            foreach (var destination in hotels)
            {
                Assert.That(destination, Has.Property("Id"));
                Assert.That(destination, Has.Property("Name"));
                Assert.That(destination, Has.Property("ImageUrl"));
                Assert.That(destination, Has.Property("Destination"));
                Assert.That(destination, Has.Property("Rating"));
            }
        }

        [Test]
        public async Task TestGetAllForTravel()
        {
            var hotels = await this.hotelService.GetAllForTravelAsync();
            var expectedCount = this.repo.AllReadonly<Hotel>().Count();

            Assert.That(hotels.Count, Is.EqualTo(expectedCount));
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

            var hotelDetails = await this.hotelService
                .GetByIdForDetailsAsync(destination.Id);

            Assert.That(hotelDetails, Is.Not.Null);
            Assert.That(hotelDetails.Name, Is.EqualTo(hotel.Name));
            Assert.That(hotelDetails.ImageUrl, Is.EqualTo(hotel.ImageUrl));
            Assert.That(hotelDetails.Destination, Is.EqualTo("New York City, USA"));
            Assert.That(hotelDetails.Rating, Is.EqualTo(hotel.Rating));
            Assert.That(hotelDetails.FoodService, Is.EqualTo("All Inclusive"));
            Assert.That(hotelDetails.HasPool, Is.EqualTo(hotel.HasPool));
            Assert.That(hotelDetails.HasSpa, Is.EqualTo(hotel.HasSpa));
            Assert.That(hotelDetails.DestinationId, Is.EqualTo(hotel.DestinationId));
        }

        [Test]
        public async Task TestGetByIdForDetailsWithInvalidId()
        {
            var hotel = await this.hotelService
                .GetByIdForDetailsAsync(-1);

            Assert.That(hotel, Is.Null);
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

            var hotelForEdit = await this.hotelService
                .GetByIdForEditAsync(destination.Id);

            Assert.That(hotelForEdit, Is.Not.Null);
            Assert.That(hotelForEdit.Name, Is.EqualTo(hotel.Name));
            Assert.That(hotelForEdit.ImageUrl, Is.EqualTo(hotel.ImageUrl));
            Assert.That(hotelForEdit.Rating, Is.EqualTo(hotel.Rating));
            Assert.That(hotelForEdit.FoodService, Is.EqualTo(hotel.FoodService));
            Assert.That(hotelForEdit.HasPool, Is.EqualTo(hotel.HasPool));
            Assert.That(hotelForEdit.HasSpa, Is.EqualTo(hotel.HasSpa));
            Assert.That(hotelForEdit.DestinationId, Is.EqualTo(hotel.DestinationId));
        }

        [Test]
        public async Task TestGetByIdForEditWithInvalidId()
        {
            var hotel = await this.hotelService
                .GetByIdForEditAsync(-1);

            Assert.That(hotel, Is.Null);
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

            var hotelForEdit = new HotelFormModel()
            {
                Name = "NYC Test Hotel",
                ImageUrl = hotel.ImageUrl,
                Rating = 4,
                FoodService = eFoodService.UltraAllInclusive,
                HasPool = hotel.HasPool,
                HasSpa = false,
                DestinationId = hotel.DestinationId
            };

            await this.hotelService.EditAsync(hotel.Id, hotelForEdit);
            var editedHotel = await this.repo.GetByIdAsync<Hotel>(hotel.Id);

            Assert.That(editedHotel.Name, Is.EqualTo(hotelForEdit.Name));
            Assert.That(editedHotel.Rating, Is.EqualTo(hotelForEdit.Rating));
            Assert.That(editedHotel.FoodService, Is.EqualTo(hotelForEdit.FoodService));
            Assert.That(editedHotel.HasSpa, Is.EqualTo(hotelForEdit.HasSpa));
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

            var initCount = this.repo.AllReadonly<Hotel>().Count();
            bool isDeleted = await this.hotelService.DeleteAsync(hotel.Id);

            Assert.That(isDeleted, Is.True);
            Assert.That(this.repo.AllReadonly<Hotel>().Count(), Is.EqualTo(initCount - 1));
        }

        [Test]
        public async Task TestDeleteNonExisting()
        {
            var initCount = this.repo.AllReadonly<Hotel>().Count();
            bool isDeleted = await this.hotelService.DeleteAsync(-1);

            Assert.That(isDeleted, Is.False);
            Assert.That(this.repo.AllReadonly<Hotel>().Count(), Is.EqualTo(initCount));
        }

        [TearDown]
        public async Task TearDown()
        {
            await this.dbContext.DisposeAsync();
        }
    }
}