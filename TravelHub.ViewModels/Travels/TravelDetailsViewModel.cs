using TravelHub.Domain.Enums;

namespace TravelHub.ViewModels.Travels
{
    public class TravelDetailsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; } = null!;

        public string Type { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public string? HotelName { get; set; }

        public decimal Price { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int PlacesLeft { get; set; }

        public string MeetingLocation { get; set; } = null!;

        public bool IsBooked { get; set; }
    }
}