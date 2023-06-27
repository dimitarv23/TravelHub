namespace TravelHub.Infrastructure
{
    using TravelHub.Domain.Models;
    using System.Reflection;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;

    public class TravelHubContext : IdentityDbContext
    {
        public TravelHubContext(DbContextOptions<TravelHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Travel> Travels { get; set; } = null!;

        public virtual DbSet<Destination> Destinations { get; set; } = null!;

        public virtual DbSet<Hotel> Hotels { get; set; } = null!;

        public virtual DbSet<Review> Reviews { get; set; } = null!;

        public virtual DbSet<Booking> Bookings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(
                Assembly.GetAssembly(typeof(TravelHubContext))!);
        }
    }
}