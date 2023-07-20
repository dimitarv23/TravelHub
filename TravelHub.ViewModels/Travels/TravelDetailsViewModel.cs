using TravelHub.Domain.Enums;

namespace TravelHub.ViewModels.Travels
{
    public class TravelDetailsViewModel : TravelViewModel
    {
        public string Description { get; set; } = null!;

        public string? HotelName { get; set; }

        public string MeetingLocation { get; set; } = null!;

        public bool IsBooked { get; set; }

        public int DestinationId { get; set; }
    }
}