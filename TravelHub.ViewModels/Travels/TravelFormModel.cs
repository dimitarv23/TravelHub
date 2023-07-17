namespace TravelHub.ViewModels.Travels
{
    using static TravelHub.Domain.Common.GlobalConstants.Travel;
    using static TravelHub.Domain.Common.GlobalConstants.Shared;
    using TravelHub.Domain.Enums;
    using System.ComponentModel.DataAnnotations;

    public class TravelFormModel
    {
        public TravelFormModel()
        {
            this.Destinations = new List<TravelDestinationViewModel>();
            this.Hotels = new List<TravelHotelViewModel>();
        }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public eTravelType Type { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateFormatString, ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateFormatString, ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        public string MeetingLocation { get; set; } = null!;

        [Required]
        [Range(NumOfPeopleMinValue, NumOfPeopleMaxValue)]
        public int MaxNumberOfPeople { get; set; }

        [Required]
        public int DestinationId { get; set; }

        public ICollection<TravelDestinationViewModel> Destinations { get; set; }

        public int HotelId { get; set; }

        public ICollection<TravelHotelViewModel> Hotels { get; set; }
    }
}