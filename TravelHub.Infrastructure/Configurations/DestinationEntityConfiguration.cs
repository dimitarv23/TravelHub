namespace TravelHub.Infrastructure.Configurations
{
    using TravelHub.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DestinationEntityConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasMany(d => d.Hotels)
                .WithOne(h => h.Destination)
                .HasForeignKey(h => h.DestinationId);

            builder.HasMany(d => d.Travels)
                .WithOne(t => t.Destination)
                .HasForeignKey(t => t.DestinationId);

            builder.HasMany(d => d.Reviews)
                .WithOne(r => r.Destination)
                .HasForeignKey(r => r.DestinationId);

            builder.HasData(this.GenerateDestinations());
        }

        private ICollection<Destination> GenerateDestinations()
        {
            return new List<Destination>()
            {
                new Destination()
                {
                    Id = 1,
                    Country = "Bulgaria",
                    Place = "Sunny Beach",
                    Currency = "BGN",
                    ImageUrl = "https://i2-prod.mylondon.news/incoming/article26617964.ece/ALTERNATES/s615b/1_GettyImages-1312067182.jpg"
                },
                new Destination()
                {
                    Id = 2,
                    Country = "Bulgaria",
                    Place = "The Seven Rila Lakes",
                    Currency = "BGN",
                    ImageUrl = "https://freesofiatour.com/wp-content/uploads/2018/05/seven-rila-lakes-how-to-get-to-1200x675.jpeg"
                },
            };
        }
    }
}