namespace TravelHub.Infrastructure.Configurations.Account
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            var identityRoleToSeed = new IdentityUserRole<string>()
            {
                UserId = "ac5688a2-417e-4a2d-973c-503b7c8eb951",
                RoleId = "613e9a9a-de45-4cec-8519-81625c7e603e"
            };

            builder.HasData(identityRoleToSeed);
        }
    }
}