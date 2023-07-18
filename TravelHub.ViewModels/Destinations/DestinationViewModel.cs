namespace TravelHub.ViewModels.Destinations
{
    public class DestinationViewModel
    {
        public int Id { get; set; }

        public string Country { get; set; } = null!;

        public string Place { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}