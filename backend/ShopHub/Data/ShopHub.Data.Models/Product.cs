namespace ShopHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Product : BaseEntity
    {  
        public Product()
        {
            CartItems = new HashSet<CartItem>(ReferenceEqualityComparer.Instance);
        }

        [Required]
        public string Name { get; set; } 

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
