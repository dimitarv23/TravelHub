namespace TravelHub.Infrastructure.Configurations
{
    using TravelHub.Domain.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ReviewEntityConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            builder.HasOne(r => r.Hotel)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.HotelId);

            builder.HasData(GenerateReviews());
        }

        private ICollection<Review> GenerateReviews()
        {
            return new List<Review>()
            {
                new Review()
                {
                    Id = 1,
                    Rating = 8,
                    Comment = "Everyting was perfect, except the food, which wasn't that good.",
                    UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                    HotelId = 1
                },
                new Review()
                {
                    Id = 2,
                    Rating = 9,
                    Comment = "I am feeling amazed by how beautiful this place is!",
                    UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                    HotelId = 1
                },
                new Review()
                {
                    Id = 3,
                    Rating = 7,
                    Comment = "I didn't really like the food, but everything else was just awesome!",
                    UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                    HotelId = 1
                }
            };
        }
    }
}