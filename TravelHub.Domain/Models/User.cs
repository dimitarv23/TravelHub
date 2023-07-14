namespace TravelHub.Domain.Models
{
    using static TravelHub.Domain.Common.GlobalConstants.User;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.Bookings = new List<Booking>();
            this.Reviews = new List<Review>();
        }

        [Required]
        [EmailAddress]
        public override string Email
        {
            get => base.Email;
            set => base.Email = value;
        }

        [Required]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength)]
        public override string UserName
        {
            get => base.UserName;
            set => base.UserName = value;
        }

        [Required]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength)]
        public string LastName { get; set; } = null!;

        [NotMapped]
        public int LoyaltyPoints => this.Bookings.Count * 10 + this.Reviews.Count;

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}