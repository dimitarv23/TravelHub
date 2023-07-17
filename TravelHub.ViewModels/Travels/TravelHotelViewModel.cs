namespace TravelHub.ViewModels.Travels
{
    using TravelHub.Domain.Enums;

    public class TravelHotelViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public eFoodService FoodService { get; set; }

        public int Rating { get; set; }

        public string Destination { get; set; }
    }
}