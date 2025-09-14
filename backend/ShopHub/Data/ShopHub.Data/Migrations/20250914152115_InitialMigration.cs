using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "ImageUrl", "ModifiedOn", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A powerful laptop with 16GB RAM, 512GB SSD, and Intel i7 processor. Perfect for work and gaming.", "product_img.jpg", null, "Laptop", 1200m },
                    { 2, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Learn modern C# and .NET 8 with practical examples and exercises. Great for beginners and professionals.", "product_img.jpg", null, "C# Book", 40m },
                    { 3, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest generation smartphone with 5G support, 128GB storage, and excellent camera quality.", "product_img.jpg", null, "Smartphone", 899m },
                    { 4, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Noise-cancelling wireless headphones with 30 hours of battery life and immersive sound quality.", "product_img.jpg", null, "Wireless Headphones", 199m },
                    { 5, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic gaming mouse with customizable RGB lighting and ultra-fast response time.", "product_img.jpg", null, "Gaming Mouse", 59.99m },
                    { 6, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable mechanical keyboard with blue switches, backlit keys, and programmable macros.", "product_img.jpg", null, "Mechanical Keyboard", 129.50m },
                    { 7, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ultra HD 27-inch monitor with vibrant colors, HDR support, and fast refresh rate for smooth gameplay.", "product_img.jpg", null, "4K Monitor", 349.99m },
                    { 8, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature-rich smartwatch with health tracking, GPS, and customizable watch faces.", "product_img.jpg", null, "Smartwatch", 249.99m },
                    { 9, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Portable Bluetooth speaker with waterproof design, 20-hour battery, and deep bass.", "product_img.jpg", null, "Bluetooth Speaker", 89.99m },
                    { 10, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1TB high-speed external SSD with USB-C connectivity and compact design.", "product_img.jpg", null, "External SSD", 159.99m },
                    { 11, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic office chair with lumbar support, adjustable height, and breathable mesh back.", "product_img.jpg", null, "Office Chair", 220m },
                    { 12, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "10-inch tablet with sharp display, stylus support, and long battery life.", "product_img.jpg", null, "Tablet", 299.99m },
                    { 13, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-capacity 20,000mAh power bank with fast charging and multiple USB outputs.", "product_img.jpg", null, "Portable Charger", 49.99m },
                    { 14, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Compact drone with 4K camera, GPS stabilization, and 30-minute flight time.", "product_img.jpg", null, "Drone", 699.00m },
                    { 15, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Immersive VR headset with high-resolution lenses and wide field of view.", "product_img.jpg", null, "VR Headset", 399.00m },
                    { 16, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Central hub for controlling smart devices, voice assistant support, and automation features.", "product_img.jpg", null, "Smart Home Hub", 149.00m },
                    { 17, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatic coffee machine with milk frother, multiple brew sizes, and programmable timer.", "product_img.jpg", null, "Coffee Machine", 349.00m },
                    { 18, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Foldable electric scooter with 25km range, LED display, and durable frame.", "product_img.jpg", null, "Electric Scooter", 549.00m },
                    { 19, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "55-inch 4K Smart TV with HDR10, built-in streaming apps, and voice control.", "product_img.jpg", null, "Smart TV", 799.00m },
                    { 20, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rugged action camera with 4K recording, waterproof housing, and wide-angle lens.", "product_img.jpg", null, "Action Camera", 299.00m },
                    { 21, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A powerful laptop with 16GB RAM, 512GB SSD, and Intel i7 processor. Perfect for work and gaming.", "product_img.jpg", null, "Laptop", 1200m },
                    { 22, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Learn modern C# and .NET 8 with practical examples and exercises. Great for beginners and professionals.", "product_img.jpg", null, "C# Book", 40m },
                    { 23, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest generation smartphone with 5G support, 128GB storage, and excellent camera quality.", "product_img.jpg", null, "Smartphone", 899m },
                    { 24, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Noise-cancelling wireless headphones with 30 hours of battery life and immersive sound quality.", "product_img.jpg", null, "Wireless Headphones", 199m },
                    { 25, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic gaming mouse with customizable RGB lighting and ultra-fast response time.", "product_img.jpg", null, "Gaming Mouse", 59.99m },
                    { 26, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable mechanical keyboard with blue switches, backlit keys, and programmable macros.", "product_img.jpg", null, "Mechanical Keyboard", 129.50m },
                    { 27, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ultra HD 27-inch monitor with vibrant colors, HDR support, and fast refresh rate for smooth gameplay.", "product_img.jpg", null, "4K Monitor", 349.99m },
                    { 28, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature-rich smartwatch with health tracking, GPS, and customizable watch faces.", "product_img.jpg", null, "Smartwatch", 249.99m },
                    { 29, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Portable Bluetooth speaker with waterproof design, 20-hour battery, and deep bass.", "product_img.jpg", null, "Bluetooth Speaker", 89.99m },
                    { 30, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1TB high-speed external SSD with USB-C connectivity and compact design.", "product_img.jpg", null, "External SSD", 159.99m },
                    { 31, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic office chair with lumbar support, adjustable height, and breathable mesh back.", "product_img.jpg", null, "Office Chair", 220m },
                    { 32, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "10-inch tablet with sharp display, stylus support, and long battery life.", "product_img.jpg", null, "Tablet", 299.99m },
                    { 33, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-capacity 20,000mAh power bank with fast charging and multiple USB outputs.", "product_img.jpg", null, "Portable Charger", 49.99m },
                    { 34, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Compact drone with 4K camera, GPS stabilization, and 30-minute flight time.", "product_img.jpg", null, "Drone", 699.00m },
                    { 35, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Immersive VR headset with high-resolution lenses and wide field of view.", "product_img.jpg", null, "VR Headset", 399.00m },
                    { 36, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Central hub for controlling smart devices, voice assistant support, and automation features.", "product_img.jpg", null, "Smart Home Hub", 149.00m },
                    { 37, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatic coffee machine with milk frother, multiple brew sizes, and programmable timer.", "product_img.jpg", null, "Coffee Machine", 349.00m },
                    { 38, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Foldable electric scooter with 25km range, LED display, and durable frame.", "product_img.jpg", null, "Electric Scooter", 549.00m },
                    { 39, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "55-inch 4K Smart TV with HDR10, built-in streaming apps, and voice control.", "product_img.jpg", null, "Smart TV", 799.00m },
                    { 40, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rugged action camera with 4K recording, waterproof housing, and wide-angle lens.", "product_img.jpg", null, "Action Camera", 299.00m },
                    { 41, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "A powerful laptop with 16GB RAM, 512GB SSD, and Intel i7 processor. Perfect for work and gaming.", "product_img.jpg", null, "Laptop", 1200m },
                    { 42, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Learn modern C# and .NET 8 with practical examples and exercises. Great for beginners and professionals.", "product_img.jpg", null, "C# Book", 40m },
                    { 43, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Latest generation smartphone with 5G support, 128GB storage, and excellent camera quality.", "product_img.jpg", null, "Smartphone", 899m },
                    { 44, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Noise-cancelling wireless headphones with 30 hours of battery life and immersive sound quality.", "product_img.jpg", null, "Wireless Headphones", 199m },
                    { 45, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic gaming mouse with customizable RGB lighting and ultra-fast response time.", "product_img.jpg", null, "Gaming Mouse", 59.99m },
                    { 46, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Durable mechanical keyboard with blue switches, backlit keys, and programmable macros.", "product_img.jpg", null, "Mechanical Keyboard", 129.50m },
                    { 47, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ultra HD 27-inch monitor with vibrant colors, HDR support, and fast refresh rate for smooth gameplay.", "product_img.jpg", null, "4K Monitor", 349.99m },
                    { 48, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Feature-rich smartwatch with health tracking, GPS, and customizable watch faces.", "product_img.jpg", null, "Smartwatch", 249.99m },
                    { 49, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Portable Bluetooth speaker with waterproof design, 20-hour battery, and deep bass.", "product_img.jpg", null, "Bluetooth Speaker", 89.99m },
                    { 50, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "1TB high-speed external SSD with USB-C connectivity and compact design.", "product_img.jpg", null, "External SSD", 159.99m },
                    { 51, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ergonomic office chair with lumbar support, adjustable height, and breathable mesh back.", "product_img.jpg", null, "Office Chair", 220m },
                    { 52, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "10-inch tablet with sharp display, stylus support, and long battery life.", "product_img.jpg", null, "Tablet", 299.99m },
                    { 53, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "High-capacity 20,000mAh power bank with fast charging and multiple USB outputs.", "product_img.jpg", null, "Portable Charger", 49.99m },
                    { 54, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Compact drone with 4K camera, GPS stabilization, and 30-minute flight time.", "product_img.jpg", null, "Drone", 699.00m },
                    { 55, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Immersive VR headset with high-resolution lenses and wide field of view.", "product_img.jpg", null, "VR Headset", 399.00m },
                    { 56, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Central hub for controlling smart devices, voice assistant support, and automation features.", "product_img.jpg", null, "Smart Home Hub", 149.00m },
                    { 57, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Automatic coffee machine with milk frother, multiple brew sizes, and programmable timer.", "product_img.jpg", null, "Coffee Machine", 349.00m },
                    { 58, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Foldable electric scooter with 25km range, LED display, and durable frame.", "product_img.jpg", null, "Electric Scooter", 549.00m },
                    { 59, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "55-inch 4K Smart TV with HDR10, built-in streaming apps, and voice control.", "product_img.jpg", null, "Smart TV", 799.00m },
                    { 60, new DateTime(2025, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Rugged action camera with 4K recording, waterproof housing, and wide-angle lens.", "product_img.jpg", null, "Action Camera", 299.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
