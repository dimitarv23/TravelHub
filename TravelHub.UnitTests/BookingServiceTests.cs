namespace TravelHub.UnitTests
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Core.Services;
    using TravelHub.Domain.Models;
    using TravelHub.Domain.Enums;
    using TravelHub.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    public class BookingServiceTests
    {
        private TravelHubContext dbContext;

        private IRepository repo = null!;

        private IBookingService bookingService = null!;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TravelHubContext>()
                .UseInMemoryDatabase("TravelHub").Options;

            this.dbContext = new TravelHubContext(contextOptions);

            this.dbContext.Database.EnsureDeletedAsync();
            this.dbContext.Database.EnsureCreatedAsync();

            this.repo = new Repository(this.dbContext);
            this.bookingService = new BookingService(this.repo);
        }

        [Test]
        public async Task TestCreateBooking()
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

            await this.repo.AddAsync(user);

            var travel = new Travel()
            {
                Id = 100,
                Type = eTravelType.BeachVacation,
                Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                Price = 780,
                DateFrom = new DateTime(2023, 7, 3),
                DateTo = new DateTime(2023, 7, 8),
                MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                MaxNumberOfPeople = 58,
                DestinationId = 1,
                HotelId = 1
            };

            await this.repo.AddAsync(travel);

            await this.bookingService.CreateBookingAsync(travel.Id, user.Id);

            // Because there are 2 seeded bookings and when we add one, there should be 3
            Assert.That(this.repo.AllReadonly<Booking>().Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task TestRemoveBooking()
        {
            await this.bookingService.RemoveBookingAsync(1, "f94b7583-61d5-4a61-a242-8c4b8fcda5a8");

            // Because there are 2 seeded bookings and when we remove one, there should be only 1 left
            Assert.That(this.repo.AllReadonly<Booking>().Count(), Is.EqualTo(1));
            Assert.That(!this.repo.All<Booking>().Any(b => b.TravelId == 1 &&
                b.UserId == "f94b7583-61d5-4a61-a242-8c4b8fcda5a8"));
        }

        [Test]
        public async Task TestGetAllBookings()
        {
            var bookings = await this.bookingService.GetAllAsync();

            // The already seeded 2 bookings
            Assert.That(bookings.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task TestGetAllBookingsForUser()
        {
            var firstUserBookings = await this.bookingService
                .GetForUserAsync("f94b7583-61d5-4a61-a242-8c4b8fcda5a8");

            var secondUserBookings = await this.bookingService
                .GetForUserAsync("ac5688a2-417e-4a2d-973c-503b7c8eb951");

            // All the seeded bookings belong to the first user
            Assert.That(firstUserBookings.Count, Is.EqualTo(2));
            Assert.That(secondUserBookings.Count, Is.EqualTo(0));
        }
    }
}