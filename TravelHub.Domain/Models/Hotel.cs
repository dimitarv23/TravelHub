namespace TravelHub.Domain.Models
{
    using static TravelHub.Domain.Common.GlobalConstants.Hotel;
    using TravelHub.Domain.Enums;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    [Table("Hotels")]
    public class Hotel
    {
        public Hotel()
        {
            this.Travels = new List<Travel>();
            this.Reviews = new List<Review>();
        }

        [Key]
        public int Id { get; set; }

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

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; } = null!;

        public virtual ICollection<Travel> Travels { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}