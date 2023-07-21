namespace TravelHub.ViewModels.Hotels
{
    public class HotelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public int Rating { get; set; }
    }
}