namespace TravelHub.Infrastructure.Configurations
{
    using TravelHub.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BookingEntityConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(pk => new { pk.UserId, pk.TravelId });

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Travel)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TravelId);

            builder.HasData(GenerateBookings());
        }

        private ICollection<Booking> GenerateBookings()
        {
            return new List<Booking>()
            {
                new Booking()
                {
                    UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                    TravelId = 1,
                    BookDate = DateTime.UtcNow
                },
                new Booking()
                {
                    UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                    TravelId = 3,
                    BookDate = DateTime.UtcNow
                },
            };
        }
    }
}