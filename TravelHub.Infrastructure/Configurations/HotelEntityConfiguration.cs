namespace TravelHub.Infrastructure.Configurations
{
    using TravelHub.Domain.Enums;
    using TravelHub.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HotelEntityConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasOne(h => h.Destination)
                .WithMany(d => d.Hotels)
                .HasForeignKey(h => h.DestinationId);

            builder.HasMany(h => h.Travels)
                .WithOne(t => t.Hotel)
                .HasForeignKey(t => t.HotelId);

            builder.Property(t => t.FoodService)
                .HasConversion(t => t.ToString(),
                    t => (eFoodService)Enum.Parse(typeof(eTravelType), t));

            builder.HasData(this.GenerateHotels());
        }

        private ICollection<Hotel> GenerateHotels()
        {
            return new List<Hotel>()
            {
                new Hotel()
                {
                    Id = 1,
                    Name = "Diamant Residence",
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/340492725.jpg?k=e27fd2bc7277de6b6794b15d1d258441ecb5e85929edc499bff3cb69e8742779&o=&hp=1",
                    Rating = 4,
                    FoodService = eFoodService.AllInclusive,
                    HasPool = true,
                    HasSpa = true,
                    DestinationId = 1
                },
                new Hotel()
                {
                    Id = 2,
                    Name = "Effect Grand Victoria Hotel",
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/60906632.jpg?k=845e3aa0d06eba8ca8a546425f6100f8b9609e836228d3c3966d45607b4807cb&o=&hp=1",
                    Rating = 4,
                    FoodService = eFoodService.UltraAllInclusive,
                    HasPool = true,
                    HasSpa = true,
                    DestinationId = 1
                }
            };
        }
    }
}