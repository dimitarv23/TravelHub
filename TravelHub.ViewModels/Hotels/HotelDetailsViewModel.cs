namespace TravelHub.ViewModels.Hotels
{
    using TravelHub.ViewModels.Reviews;

    public class HotelDetailsViewModel : HotelViewModel
    {
        public HotelDetailsViewModel()
        {
            this.Reviews = new List<ReviewViewModel>();
        }

        public string FoodService { get; set; } = null!;

        public bool HasPool { get; set; }

        public bool HasSpa { get; set; }

        public int DestinationId { get; set; }

        public virtual ICollection<ReviewViewModel> Reviews { get; set; }
    }
}