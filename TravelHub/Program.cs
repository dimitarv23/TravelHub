namespace TravelHub
{
    using TravelHub.Core.Extensions;
    using TravelHub.Domain.Models;
    using TravelHub.Infrastructure;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<TravelHubContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = builder.Configuration
                    .GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
                options.Password.RequiredLength = builder.Configuration
                    .GetValue<int>("Identity:Password:RequiredLength");
                options.Password.RequireDigit = builder.Configuration
                    .GetValue<bool>("Identity:Password:RequireDigit");
                options.Password.RequireUppercase = builder.Configuration
                    .GetValue<bool>("Identity:Password:RequireUppercase");
                options.Password.RequireLowercase = builder.Configuration
                    .GetValue<bool>("Identity:Password:RequireLowercase");
                options.Password.RequireNonAlphanumeric = builder.Configuration
                    .GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<TravelHubContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Error/AccessDenied";
                options.LoginPath = "/User/Login";
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddApplicationServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStatusCodePagesWithRedirects("/Errors/{0}");
            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}