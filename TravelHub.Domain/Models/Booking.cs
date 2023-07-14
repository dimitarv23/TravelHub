namespace TravelHub.Domain.Models
{
    using static TravelHub.Domain.Common.GlobalConstants.Shared;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Bookings")]
    public class Booking
    {
        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public int TravelId { get; set; }

        [ForeignKey(nameof(TravelId))]
        public Travel Travel { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = DateFormatString, ApplyFormatInEditMode = true)]
        public DateTime BookDate { get; set; }
    }
}