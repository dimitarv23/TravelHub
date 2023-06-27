namespace TravelHub.Infrastructure.Configurations
{
    using TravelHub.Domain.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Bookings)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.HasData(GenerateOrganizer());
        }

        private User GenerateOrganizer()
        {
            var hasher = new PasswordHasher<User>();

            var organizer = new User()
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = "Organizer",
                LastName = "Organizer",
                UserName = "Organizer1",
                NormalizedUserName = "ORGANIZER1",
                Email = "organizer@email.com",
                NormalizedEmail = "ORGANIZER@EMAIL.COM"
            };

            organizer.PasswordHash = hasher.HashPassword(organizer, "Organizer123");
            return organizer;
        }
    }
}