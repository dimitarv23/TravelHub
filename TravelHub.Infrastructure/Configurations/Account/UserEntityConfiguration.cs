namespace TravelHub.Infrastructure.Configurations.Account
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
                Id = "ac5688a2-417e-4a2d-973c-503b7c8eb951",
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