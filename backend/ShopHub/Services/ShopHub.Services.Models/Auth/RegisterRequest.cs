namespace ShopHub.Services.Models.Auth
{
    using System.ComponentModel.DataAnnotations;

    using ShopHub.Common;

    public class RegisterRequest : BaseAuth
    {
        [StringLength(ValidationConstants.FULL_NAME_MAX_LENGTH)]
        public string FullName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
    }
}
