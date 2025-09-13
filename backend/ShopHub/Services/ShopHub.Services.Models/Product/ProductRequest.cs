namespace ShopHub.Services.Models.Product
{
    using System.ComponentModel.DataAnnotations;

    public class ProductRequest
    {
        [Required]
        public int Page { get; set; }

        [Required]
        public int PageSize { get; set; }
    }
}
