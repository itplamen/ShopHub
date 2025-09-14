namespace ShopHub.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using ShopHub.Data.Models;

    public class ShopHubDbContext : IdentityDbContext<User, Role, int>
    {
        public ShopHubDbContext(DbContextOptions<ShopHubDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            builder.Entity<User>()
                   .HasOne(u => u.Cart)
                   .WithOne(c => c.User)
                   .HasForeignKey<Cart>(c => c.UserId);

            builder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            var seed = Enumerable.Range(0, 3)
                .SelectMany(_ => DataSeedProvider.GetProducts())
                .Select((product, index) =>
                {
                    product.Id = index + 1;
                    return product;
                });

            builder.Entity<Product>().HasData(seed);

            base.OnModelCreating(builder);
        }
    }
}
