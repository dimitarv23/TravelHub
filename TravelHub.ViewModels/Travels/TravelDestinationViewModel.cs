namespace TravelHub.ViewModels.Travels
{
    public class TravelDestinationViewModel
    {
        public TravelDestinationViewModel()
        {
            this.Hotels = new List<TravelHotelViewModel>();
        }

        public int Id { get; set; }

        public string Country { get; set; } = null!;

        public string Place { get; set; } = null!;

        public ICollection<TravelHotelViewModel> Hotels { get; set; }
    }
}