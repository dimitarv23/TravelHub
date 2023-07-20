namespace TravelHub.Infrastructure.Configurations.Account
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GenerateUserRoles());
        }

        private ICollection<IdentityUserRole<string>> GenerateUserRoles()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    UserId = "ac5688a2-417e-4a2d-973c-503b7c8eb951",
                    RoleId = "613e9a9a-de45-4cec-8519-81625c7e603e"
                },
                new IdentityUserRole<string>()
                {
                    UserId = "f94b7583-61d5-4a61-a242-8c4b8fcda5a8",
                    RoleId = "4c4fa568-5033-40d9-8064-9db512d3de49"
                }
            };
        }
    }
}