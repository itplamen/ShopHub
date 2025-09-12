 namespace ShopHub.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using ShopHub.Data.Models.Contracts;

    public abstract class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
