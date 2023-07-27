namespace TravelHub.UnitTests
{
    using TravelHub.Core.Contracts;
    using TravelHub.Core.Repositories;
    using TravelHub.Infrastructure;
    using Microsoft.EntityFrameworkCore;

    [TestFixture]
    public class BookingServiceTests
    {
        private IRepository repo = null!;

        private IBookingService bookingService = null!;

        private TravelHubContext dbContext;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<TravelHubContext>()
                .UseInMemoryDatabase("TravelHub")
                .Options;

            this.dbContext = new TravelHubContext(contextOptions);

            this.dbContext.Database.EnsureDeletedAsync();
            this.dbContext.Database.EnsureCreatedAsync();
        }
    }
}