﻿namespace TravelHub.Domain.Models
{
    using static TravelHub.Domain.Common.GlobalConstants.Review;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Reviews")]
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [StringLength(CommentMaxLength, MinimumLength = CommentMinLength)]
        public string? Comment { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public int HotelId { get; set; }

        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; } = null!;
    }
}