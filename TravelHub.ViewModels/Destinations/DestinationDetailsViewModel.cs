using TravelHub.ViewModels.Reviews;

namespace TravelHub.ViewModels.Destinations
{
    public class DestinationDetailsViewModel : DestinationViewModel
    {
        public DestinationDetailsViewModel()
        {
            this.Hotels = new List<DestinationHotelViewModel>();
            this.Reviews = new List<ReviewViewModel>();
        }

        public string Currency { get; set; } = null!;

        public virtual ICollection<DestinationHotelViewModel> Hotels { get; set; }

        public virtual ICollection<ReviewViewModel> Reviews { get; set; }
    }
}