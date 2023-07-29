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

            var travel = new Travel()
            {
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

            await this.repo.AddAsync(user);
            await this.repo.AddAsync(travel);
            await this.repo.SaveChangesAsync();

            var initCount = this.repo.AllReadonly<Booking>().Count();
            await this.bookingService.CreateBookingAsync(travel.Id, user.Id);

            Assert.That(this.repo.AllReadonly<Booking>().Count(), Is.EqualTo(initCount + 1));
        }

        [Test]
        public async Task TestCreateDuplicate()
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

            var travel = new Travel()
            {
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

            await this.repo.AddAsync(user);
            await this.repo.AddAsync(travel);
            await this.repo.SaveChangesAsync();

            var initCount = this.repo.AllReadonly<Booking>().Count();

            await this.bookingService.CreateBookingAsync(travel.Id, user.Id);
            await this.bookingService.CreateBookingAsync(travel.Id, user.Id);

            Assert.That(this.repo.AllReadonly<Booking>().Count(), Is.EqualTo(initCount + 1));
        }

        [Test]
        public async Task TestRemove()
        {
            var user = new User()
            {
                Id = "3642082d-33c9-45d0-9dbb-755e9024c068",
                FirstName = "TestUser",
                LastName = "TestUser",
                UserName = "Test_User",
                NormalizedUserName = "TEST_USER",
                Email = "test@email.com",
                NormalizedEmail = "TEST@EMAIL.COM"
            };

            var travel = new Travel()
            {
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

            await this.repo.AddAsync(user);
            await this.repo.AddAsync(travel);
            await this.repo.AddAsync(new Booking()
            {
                UserId = "3642082d-33c9-45d0-9dbb-755e9024c068",
                TravelId = travel.Id,
                BookDate = DateTime.UtcNow
            });

            await this.repo.SaveChangesAsync();

            var initCount = this.repo.AllReadonly<Booking>().Count();

            await this.bookingService.RemoveBookingAsync(travel.Id, "3642082d-33c9-45d0-9dbb-755e9024c068");

            Assert.That(this.repo.AllReadonly<Booking>().Count(), Is.EqualTo(initCount - 1));
            Assert.That(!this.repo.All<Booking>().Any(b => b.TravelId == travel.Id &&
                b.UserId == "3642082d-33c9-45d0-9dbb-755e9024c068"));
        }

        [Test]
        public async Task TestRemoveNonExisting()
        {
            await this.bookingService.RemoveBookingAsync(2000, "15c69173-cf4f-4048-8da6-98f8f55463a2");

            var initCount = this.repo.AllReadonly<Booking>().Count();

            Assert.That(this.repo.AllReadonly<Booking>().Count(), Is.EqualTo(initCount));
        }

        [Test]
        public async Task TestGetAll()
        {
            var bookings = await this.bookingService.GetAllAsync();

            var initCount = this.repo.AllReadonly<Booking>().Count();

            Assert.That(bookings.Count, Is.EqualTo(initCount));

            foreach (var booking in bookings)
            {
                Assert.That(booking, Has.Property("Destination"));
                Assert.That(booking, Has.Property("ImageUrl"));
                Assert.That(booking, Has.Property("Price"));
                Assert.That(booking, Has.Property("Owner"));
                Assert.That(booking, Has.Property("DateFrom"));
                Assert.That(booking, Has.Property("DateTo"));
                Assert.That(booking, Has.Property("BookDate"));
                Assert.That(booking, Has.Property("TravelId"));
                Assert.That(booking, Has.Property("UserId"));
            }
        }

        [Test]
        public async Task TestGetAllForUser()
        {
            var user = new User()
            {
                Id = "8924d72c-d316-4826-b86c-e975ea33ba4f",
                FirstName = "TestUser",
                LastName = "TestUser",
                UserName = "Test_User",
                NormalizedUserName = "TEST_USER",
                Email = "test@email.com",
                NormalizedEmail = "TEST@EMAIL.COM"
            };

            var travel = new Travel()
            {
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

            await this.repo.AddAsync(user);
            await this.repo.AddAsync(travel);
            await this.repo.AddRangeAsync(new List<Booking>()
            {
                new Booking()
                {
                    UserId = "8924d72c-d316-4826-b86c-e975ea33ba4f",
                    TravelId = travel.Id,
                    BookDate = DateTime.UtcNow
                }
            });

            await this.repo.SaveChangesAsync();

            var userBookings = await this.bookingService
                .GetForUserAsync("8924d72c-d316-4826-b86c-e975ea33ba4f");

            Assert.That(userBookings.Count, Is.EqualTo(1));
        }

        [TearDown]
        public async Task TearDown()
        {
            await this.dbContext.DisposeAsync();
        }
    }
}