namespace TravelHub.UnitTests
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;
    using TravelHub.Domain.Enums;
    using TravelHub.Domain.Models;
    using TravelHub.Infrastructure;
    using TravelHub.ViewModels.Reviews;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    public class ReviewServiceTests
    {
        private TravelHubContext dbContext;

        private IRepository repo = null!;

        private IReviewService reviewService = null!;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TravelHubContext>()
                .UseInMemoryDatabase("TravelHub").Options;

            this.dbContext = new TravelHubContext(contextOptions);

            this.dbContext.Database.EnsureDeletedAsync();
            this.dbContext.Database.EnsureCreatedAsync();

            this.repo = new Repository(this.dbContext);
            this.reviewService = new ReviewService(this.repo);
        }

        [Test]
        public async Task TestCreate()
        {
            var user = new User()
            {
                Id = "fe40d434-3a94-4f74-91aa-bb9d0beab3b9",
                FirstName = "Test",
                LastName = "Test",
                UserName = "Test_User",
                NormalizedUserName = "TEST_USER",
                Email = "test@email.com",
                NormalizedEmail = "TEST@EMAIL.COM"
            };

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = 1
            };

            await this.repo.AddAsync(user);
            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var review = new AddReviewViewModel()
            {
                Comment = "Test comment.",
                AuthorId = user.Id,
                HotelId = hotel.Id,
                DateAdded = DateTime.UtcNow
            };

            var initCount = this.repo.AllReadonly<Review>().Count();
            await this.reviewService.AddAsync(review);

            Assert.That(this.repo.AllReadonly<Review>().Count(), Is.EqualTo(initCount + 1));
        }

        [Test]
        public async Task TestDelete()
        {
            var user = new User()
            {
                Id = "fe40d434-3a94-4f74-91aa-bb9d0beab3b9",
                FirstName = "Test",
                LastName = "Test",
                UserName = "Test_User",
                NormalizedUserName = "TEST_USER",
                Email = "test@email.com",
                NormalizedEmail = "TEST@EMAIL.COM"
            };

            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = 1
            };

            await this.repo.AddAsync(user);
            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var review = new Review()
            {
                Comment = "Test comment.",
                UserId = user.Id,
                HotelId = hotel.Id,
                DateAdded = DateTime.UtcNow
            };

            await this.repo.AddAsync(review);
            await this.repo.SaveChangesAsync();

            var initCount = this.repo.AllReadonly<Review>().Count();
            int forHotelId = await this.reviewService.DeleteAsync(review.Id);

            Assert.That(this.repo.AllReadonly<Review>().Count(), Is.EqualTo(initCount - 1));
            Assert.That(forHotelId, Is.EqualTo(hotel.Id));
        }

        [Test]
        public async Task TestDeleteNonExisting()
        {
            var initCount = this.repo.AllReadonly<Review>().Count();
            int hotelId = await this.reviewService.DeleteAsync(-1);

            Assert.That(hotelId, Is.EqualTo(0));
            Assert.That(this.repo.AllReadonly<Review>().Count(), Is.EqualTo(initCount));
        }

        [Test]
        public async Task TestGetAllForHotel()
        {
            var hotel = new Hotel()
            {
                Name = "NYC Hotel",
                ImageUrl = "https://media.cntraveler.com/photos/63483e15ef943eff59de603a/16:9/w_3000,h_1687,c_limit/New%20York%20City_GettyImages-1347979016.jpg",
                Rating = 5,
                FoodService = eFoodService.AllInclusive,
                HasPool = true,
                HasSpa = true,
                DestinationId = 1
            };

            await this.repo.AddAsync(hotel);
            await this.repo.SaveChangesAsync();

            var reviews = await this.reviewService.GetAllForHotelAsync(hotel.Id);
            var expectedCount = this.repo.AllReadonly<Review>()
                .Where(r => r.HotelId == hotel.Id)
                .Count();

            Assert.That(reviews.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public async Task TestGetAllForHotelWithInvalidHotelId()
        {
            var reviews = await this.reviewService.GetAllForHotelAsync(-1);

            Assert.That(reviews.Count, Is.EqualTo(0));
        }

        [TearDown]
        public async Task TearDown()
        {
            await this.dbContext.DisposeAsync();
        }
    }
}