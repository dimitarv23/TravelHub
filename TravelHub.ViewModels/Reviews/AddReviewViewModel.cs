namespace TravelHub.ViewModels.Reviews
{
    using static TravelHub.Domain.Common.GlobalConstants.Review;
    using System.ComponentModel.DataAnnotations;

    public class AddReviewViewModel
    {
        [Required]
        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string Comment { get; set; } = null!;

        [Required]
        public string AuthorId { get; set; } = null!;

        [Required]
        public int HotelId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
    }
}