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

            builder.HasMany(h => h.Reviews)
                .WithOne(r => r.Hotel)
                .HasForeignKey(r => r.HotelId);

            builder.Property(h => h.FoodService)
                .HasConversion(f => f.ToString(),
                    t => (eFoodService)Enum.Parse(typeof(eFoodService), t));

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
                },
                new Hotel()
                {
                    Id = 3,
                    Name = "Grand Hotel Plovdiv",
                    ImageUrl = "https://cf.bstatic.com/xdata/images/hotel/max1024x768/207378277.jpg?k=a3ff6dfc7bc9855ae08aacacb71f51863a8b0e41b90d0384c700456a79e7b72c&o=&hp=1",
                    Rating = 5,
                    FoodService = eFoodService.AllInclusive,
                    HasPool = true,
                    HasSpa = true,
                    DestinationId = 3
                },
                new Hotel()
                {
                    Id = 4,
                    Name = "Galaxy Hotel",
                    ImageUrl = "https://ak-d.tripcdn.com/images/200l0m000000dw3kcBD54_R_550_412_R5.jpg",
                    Rating = 4,
                    FoodService = eFoodService.BreakfastOnly,
                    HasPool = true,
                    HasSpa = false,
                    DestinationId = 4
                }
            };
        }
    }
}