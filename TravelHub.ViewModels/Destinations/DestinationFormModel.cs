namespace TravelHub.ViewModels.Destinations
{
    using static TravelHub.Domain.Common.GlobalConstants.Destination;
    using System.ComponentModel.DataAnnotations;

    public class DestinationFormModel
    {
        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;

        [Required]
        [StringLength(PlaceMaxLength, MinimumLength = PlaceMinLength)]
        public string Place { get; set; } = null!;

        [Required]
        [StringLength(CurrencyMaxLength, MinimumLength = CurrencyMinLength)]
        public string Currency { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;
    }
}