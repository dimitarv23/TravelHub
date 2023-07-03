namespace TravelHub.ViewModels.Account
{
    using static TravelHub.Domain.Common.GlobalConstants.User;
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(NamesMaxLength, MinimumLength = NamesMinLength)]
        public string Username { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}