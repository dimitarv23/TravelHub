namespace TravelHub.Infrastructure.Configurations.Account
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
                    Id = "4c4fa568-5033-40d9-8064-9db512d3de49",
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole()
                {
                    Id = "613e9a9a-de45-4cec-8519-81625c7e603e",
                    Name = "Organizer",
                    NormalizedName = "ORGANIZER"
                }
            };

            builder.HasData(rolesToSeed);
        }
    }
}