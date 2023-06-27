namespace TravelHub.Infrastructure.Configurations
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoleEntityConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            var rolesToSeed = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole()
                {
                    Name = "Organizer",
                    NormalizedName = "ORGANIZER"
                }
            };

            builder.HasData(rolesToSeed);
        }
    }
}