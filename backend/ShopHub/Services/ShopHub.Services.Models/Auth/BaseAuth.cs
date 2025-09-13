namespace ShopHub.Services.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    using ShopHub.Common;

    public abstract class BaseAuth
    {
        [Required(
            ErrorMessageResourceType = typeof(ErrorMessages), 
            ErrorMessageResourceName = "UsernameRequired")]
        [StringLength(
            ValidationConstants.USERNAME_MAX_LENGTH,
            MinimumLength = ValidationConstants.USERNAME_MIN_LENGTH,
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "UsernameLength")]
        public string Username { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "PasswordRequired")]
        [StringLength(
            ValidationConstants.PASSWORD_MAX_LENGTH,
            MinimumLength = ValidationConstants.PASSWORD_MIN_LENGTH,
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "PasswordLength")]
        [RegularExpression(
            ValidationConstants.PASSWORD_REGEX,
            ErrorMessageResourceType = typeof(ErrorMessages),
            ErrorMessageResourceName = "PasswordCharacters")]
        public string Password { get; set; }
    }
}
