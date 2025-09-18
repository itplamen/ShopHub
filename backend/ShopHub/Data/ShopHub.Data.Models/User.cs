namespace ShopHub.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
    
    using ShopHub.Data.Models.Contracts;

    public class User : IdentityUser<int>, IEntity
    {
        public User()
        {
            Notifications = new HashSet<Notification>(ReferenceEqualityComparer.Instance);
            RefreshTokens = new HashSet<RefreshToken>(ReferenceEqualityComparer.Instance);
        } 

        public string FullName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public Cart Cart { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
    }
}
