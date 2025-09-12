namespace ShopHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart : BaseEntity
    {
        public Cart()
        {
            Items = new HashSet<CartItem>(ReferenceEqualityComparer.Instance);
        }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; } 

        public ICollection<CartItem> Items { get; set; }

        [NotMapped]
        public decimal Total => Items.Sum(i => i.Quantity * i.Product.Price);
    }
}
