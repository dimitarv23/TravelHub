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
        }
    }
}