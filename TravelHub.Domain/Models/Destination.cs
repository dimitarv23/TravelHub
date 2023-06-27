namespace TravelHub.Domain.Models
{
    using static Common.GlobalConstants.Destination;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Destinations")]
    public class Destination
    {
        public Destination()
        {
            this.Hotels = new List<Hotel>();
            this.Travels = new List<Travel>();
            this.Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

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

        public virtual ICollection<Hotel> Hotels { get; set; }

        public virtual ICollection<Travel> Travels { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}