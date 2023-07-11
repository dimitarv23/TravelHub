namespace TravelHub.ViewModels.Account
{
    using static TravelHub.Domain.Common.GlobalConstants.User;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [Required]
        public string UsernameOrEmail { get; set; } = null!;

        [Required]
        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public bool RememberMe { get; set; }
    }
}