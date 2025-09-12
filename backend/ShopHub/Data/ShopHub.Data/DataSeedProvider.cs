namespace ShopHub.Data
{
    using ShopHub.Data.Models;

    public static class DataSeedProvider
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "A powerful laptop with 16GB RAM, 512GB SSD, and Intel i7 processor. Perfect for work and gaming.",
                    Price = 1200m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 2,
                    Name = "C# Book",
                    Description = "Learn modern C# and .NET 8 with practical examples and exercises. Great for beginners and professionals.",
                    Price = 40m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 3,
                    Name = "Smartphone",
                    Description = "Latest generation smartphone with 5G support, 128GB storage, and excellent camera quality.",
                    Price = 899m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 4,
                    Name = "Wireless Headphones",
                    Description = "Noise-cancelling wireless headphones with 30 hours of battery life and immersive sound quality.",
                    Price = 199m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 5,
                    Name = "Gaming Mouse",
                    Description = "Ergonomic gaming mouse with customizable RGB lighting and ultra-fast response time.",
                    Price = 59.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 6,
                    Name = "Mechanical Keyboard",
                    Description = "Durable mechanical keyboard with blue switches, backlit keys, and programmable macros.",
                    Price = 129.50m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 7,
                    Name = "4K Monitor",
                    Description = "Ultra HD 27-inch monitor with vibrant colors, HDR support, and fast refresh rate for smooth gameplay.",
                    Price = 349.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 8,
                    Name = "Smartwatch",
                    Description = "Feature-rich smartwatch with health tracking, GPS, and customizable watch faces.",
                    Price = 249.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 9,
                    Name = "Bluetooth Speaker",
                    Description = "Portable Bluetooth speaker with waterproof design, 20-hour battery, and deep bass.",
                    Price = 89.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 10,
                    Name = "External SSD",
                    Description = "1TB high-speed external SSD with USB-C connectivity and compact design.",
                    Price = 159.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 11,
                    Name = "Office Chair",
                    Description = "Ergonomic office chair with lumbar support, adjustable height, and breathable mesh back.",
                    Price = 220m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 12,
                    Name = "Tablet",
                    Description = "10-inch tablet with sharp display, stylus support, and long battery life.",
                    Price = 299.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 13,
                    Name = "Portable Charger",
                    Description = "High-capacity 20,000mAh power bank with fast charging and multiple USB outputs.",
                    Price = 49.99m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 14,
                    Name = "Drone",
                    Description = "Compact drone with 4K camera, GPS stabilization, and 30-minute flight time.",
                    Price = 699.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 15,
                    Name = "VR Headset",
                    Description = "Immersive VR headset with high-resolution lenses and wide field of view.",
                    Price = 399.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 16,
                    Name = "Smart Home Hub",
                    Description = "Central hub for controlling smart devices, voice assistant support, and automation features.",
                    Price = 149.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 17,
                    Name = "Coffee Machine",
                    Description = "Automatic coffee machine with milk frother, multiple brew sizes, and programmable timer.",
                    Price = 349.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 18,
                    Name = "Electric Scooter",
                    Description = "Foldable electric scooter with 25km range, LED display, and durable frame.",
                    Price = 549.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 19,
                    Name = "Smart TV",
                    Description = "55-inch 4K Smart TV with HDR10, built-in streaming apps, and voice control.",
                    Price = 799.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                },
                new Product
                {
                    Id = 20,
                    Name = "Action Camera",
                    Description = "Rugged action camera with 4K recording, waterproof housing, and wide-angle lens.",
                    Price = 299.00m,
                    ImageUrl = "product_img.jpg",
                    CreatedOn = new DateTime(2025, 9, 12)
                }
            };
        }
    }
}
