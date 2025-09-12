namespace ShopHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CartItem : BaseEntity
    {
        [Required]
        public int Quantity { get; set; }

        [Required]
        public int CartId { get; set; }

        public Cart Cart { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
