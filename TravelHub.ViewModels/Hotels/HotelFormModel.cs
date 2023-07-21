namespace TravelHub.ViewModels.Hotels
{
    using static TravelHub.Domain.Common.GlobalConstants.Hotel;
    using TravelHub.Domain.Enums;
    using TravelHub.ViewModels.Destinations;
    using System.ComponentModel.DataAnnotations;

    public class HotelFormModel
    {
        public HotelFormModel()
        {
            this.Destinations = new List<SelectDestinationViewModel>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public int Rating { get; set; }

        [Required]
        public eFoodService FoodService { get; set; }

        [Required]
        public bool HasPool { get; set; }

        [Required]
        public bool HasSpa { get; set; }

        [Required]
        public int DestinationId { get; set; }

        public ICollection<SelectDestinationViewModel> Destinations { get; set; }
    }
}