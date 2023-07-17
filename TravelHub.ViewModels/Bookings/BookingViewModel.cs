namespace TravelHub.ViewModels.Bookings
{
    public class BookingViewModel
    {
        public string Destination { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

        public string Owner { get; set; } = null!;

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public DateTime BookDate { get; set; }

        public int TravelId { get; set; }

        public string UserId { get; set; } = null!;
    }
}