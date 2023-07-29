namespace TravelHub.UnitTests
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;
    using TravelHub.Domain.Models;
    using TravelHub.Infrastructure;
    using TravelHub.ViewModels.Destinations;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    public class DestinationServiceTests
    {
        private TravelHubContext dbContext;

        private IRepository repo = null!;

        private IDestinationService destinationService = null!;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TravelHubContext>()
                .UseInMemoryDatabase("TravelHub").Options;

            this.dbContext = new TravelHubContext(contextOptions);

            this.dbContext.Database.EnsureDeletedAsync();
            this.dbContext.Database.EnsureCreatedAsync();

            this.repo = new Repository(this.dbContext);
            this.destinationService = new DestinationService(this.repo);
        }

        [Test]
        public async Task TestCreate()
        {
            var destinationToAdd = new DestinationFormModel()
            {
                Country = "USA",
                Place = "New York City",
                Currency = "USD",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg"
            };

            var initCount = this.repo.AllReadonly<Destination>().Count();
            await this.destinationService.CreateAsync(destinationToAdd);

            Assert.That(this.repo.AllReadonly<Destination>().Count(), Is.EqualTo(initCount + 1));
        }

        [Test]
        public async Task TestCreateWithDuplicateCountryAndPlace()
        {
            var destinationToAdd = new DestinationFormModel()
            {
                Country = "Bulgaria",
                Place = "The Seven Rila Lakes",
                Currency = "BGN",
                ImageUrl = "https://freesofiatour.com/wp-content/uploads/2018/05/seven-rila-lakes-how-to-get-to-1200x675.jpeg"
            };

            var initCount = this.repo.AllReadonly<Destination>().Count();
            await this.destinationService.CreateAsync(destinationToAdd);

            Assert.That(this.repo.AllReadonly<Destination>().Count(), Is.EqualTo(initCount));
        }

        [Test]
        public async Task TestGetAll()
        {
            var destinations = await this.destinationService.GetAllAsync();
            var expectedCount = this.repo.AllReadonly<Destination>().Count();

            Assert.That(destinations.Count, Is.EqualTo(expectedCount));

            foreach (var destination in destinations)
            {
                Assert.That(destination, Has.Property("Id"));
                Assert.That(destination, Has.Property("Country"));
                Assert.That(destination, Has.Property("Place"));
                Assert.That(destination, Has.Property("ImageUrl"));
            }
        }

        [Test]
        public async Task TestGetAllForSelection()
        {
            var destinations = await this.destinationService.GetAllForSelectionAsync();
            var expectedCount = this.repo.AllReadonly<Destination>().Count();

            Assert.That(destinations.Count, Is.EqualTo(expectedCount));

            foreach (var destination in destinations)
            {
                Assert.That(destination, Has.Property("Id"));
                Assert.That(destination, Has.Property("Country"));
                Assert.That(destination, Has.Property("Place"));
            }
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

            var destinationDetails = await this.destinationService
                .GetByIdForDetailsAsync(destination.Id);

            Assert.That(destinationDetails, Is.Not.Null);
            Assert.That(destinationDetails.Country, Is.EqualTo(destination.Country));
            Assert.That(destinationDetails.Place, Is.EqualTo(destination.Place));
            Assert.That(destinationDetails.Currency, Is.EqualTo(destination.Currency));
            Assert.That(destinationDetails.ImageUrl, Is.EqualTo(destination.ImageUrl));
        }

        [Test]
        public async Task TestGetByIdForDetailsWithInvalidId()
        {
            var destination = await this.destinationService
                .GetByIdForDetailsAsync(-1);

            Assert.That(destination, Is.Null);
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

            var initCount = this.repo.AllReadonly<Destination>().Count();
            bool isDeleted = await this.destinationService.DeleteAsync(destination.Id);

            Assert.That(isDeleted, Is.True);
            Assert.That(this.repo.AllReadonly<Destination>().Count(), Is.EqualTo(initCount - 1));
        }

        [Test]
        public async Task TestDeleteNonExisting()
        {
            var initCount = this.repo.AllReadonly<Destination>().Count();
            bool isDeleted = await this.destinationService.DeleteAsync(-1);

            Assert.That(isDeleted, Is.False);
            Assert.That(this.repo.AllReadonly<Destination>().Count(), Is.EqualTo(initCount));
        }

        [TearDown]
        public async Task TearDown()
        {
            await this.dbContext.DisposeAsync();
        }
    }
}