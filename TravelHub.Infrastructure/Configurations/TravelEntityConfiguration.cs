namespace TravelHub.Infrastructure.Configurations
{
    using TravelHub.Domain.Enums;
    using TravelHub.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TravelEntityConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.HasOne(t => t.Destination)
                .WithMany(d => d.Travels)
                .HasForeignKey(t => t.DestinationId);

            builder.HasOne(t => t.Hotel)
                .WithMany(h => h.Travels)
                .HasForeignKey(t => t.HotelId);

            builder.HasMany(t => t.Bookings)
                .WithOne(b => b.Travel)
                .HasForeignKey(b => b.TravelId);

            builder.Property(t => t.Type)
                .HasConversion(t => t.ToString(),
                    t => (eTravelType)Enum.Parse(typeof(eTravelType), t));

            builder.HasData(this.GenerateTravels());
        }

        private ICollection<Travel> GenerateTravels()
        {
            return new List<Travel>()
            {
                new Travel()
                {
                    Id = 1,
                    Type = eTravelType.BeachVacation,
                    Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 03/07/2023 and we will be back in town at around 7PM on 08/07/2023. Come and party with us!",
                    Price = 780,
                    DateFrom = new DateTime(2023, 7, 3),
                    DateTo = new DateTime(2023, 7, 8),
                    MeetingLocation = "Hotel 'Alen Mak', Blagoevgrad",
                    MaxNumberOfPeople = 58,
                    DestinationId = 1,
                    HotelId = 1
                },
                new Travel()
                {
                    Id = 2,
                    Type = eTravelType.BeachVacation,
                    Description = "A vacation on sunny beach for 6 days for a great amount of money! The bus leaves at 4AM on 10/07/2023 and we will be back in town at around 7PM on 16/07/2023. Come and party with us!",
                    Price = 820,
                    DateFrom = new DateTime(2023, 7, 10),
                    DateTo = new DateTime(2023, 7, 16),
                    MeetingLocation = "Hotel 'Ezerets', Blagoevgrad",
                    MaxNumberOfPeople = 62,
                    DestinationId = 1,
                    HotelId = 2
                },
                new Travel()
                {
                    Id = 3,
                    Type = eTravelType.MountainVacation,
                    Description = "A mountain hike to gorgeous Seven Rila Lakes. We are starting our trip at 8AM on 02/07/2023 and will be back in town around 5PM on the same day. Come with us to enjoy the beauty of our bulgarian nature!",
                    Price = 30,
                    DateFrom = new DateTime(2023, 7, 2),
                    DateTo = new DateTime(2023, 7, 2),
                    MeetingLocation = "Park 'Bachinovo', Blagoevgrad",
                    MaxNumberOfPeople = 40,
                    DestinationId = 2
                }
            };
        }
    }
}