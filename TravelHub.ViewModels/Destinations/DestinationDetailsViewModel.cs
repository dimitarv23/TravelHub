namespace TravelHub.ViewModels.Destinations
{
    public class DestinationDetailsViewModel : DestinationViewModel
    {
        public DestinationDetailsViewModel()
        {
            this.Hotels = new List<DestinationHotelViewModel>();
        }

        public string Currency { get; set; } = null!;

        public virtual ICollection<DestinationHotelViewModel> Hotels { get; set; }
    }
}