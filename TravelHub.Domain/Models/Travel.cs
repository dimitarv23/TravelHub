namespace TravelHub.Domain.Models
{
    using static Common.GlobalConstants.Travel;
    using static Common.GlobalConstants.Shared;
    using TravelHub.Domain.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Travels")]
    public class Travel
    {
        public Travel()
        {
            this.Bookings = new List<Booking>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public eTravelType Type { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateFormat, ApplyFormatInEditMode = true)]
        public DateTime DateFrom { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = DateFormat, ApplyFormatInEditMode = true)]
        public DateTime DateTo { get; set; }

        public string MeetingLocation { get; set; } = null!;

        [Required]
        [Range(NumOfPeopleMinValue, NumOfPeopleMaxValue)]
        public int MaxNumberOfPeople { get; set; }

        [NotMapped]
        public int PlacesLeft => this.MaxNumberOfPeople - this.Bookings.Count;

        [Required]
        public int DestinationId { get; set; }

        [ForeignKey(nameof(DestinationId))]
        public Destination Destination { get; set; } = null!;

        public int? HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel? Hotel { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}