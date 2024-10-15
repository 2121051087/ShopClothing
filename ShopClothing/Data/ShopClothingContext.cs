using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Models;

namespace ShopClothing.Data
{
    public class ShopClothingContext : IdentityDbContext<ApplicationUser>
    {
        public ShopClothingContext(DbContextOptions<ShopClothingContext> options) : base(options)
        {
        }

        public DbSet<ShopClothing.Models.Categories> Categories { get; set; }
        public DbSet<ShopClothing.Models.Colors> Colors { get; set; }
        public DbSet<ShopClothing.Models.ColorSizes> ColorSizes { get; set; }
        public DbSet<ShopClothing.Models.Products> Products { get; set; }
        public DbSet<ShopClothing.Models.Sizes> Sizes { get; set; }
        public DbSet<ShopClothing.Models.Orders> Orders { get; set; }
        public DbSet<ShopClothing.Models.OrderDetails> OrderDetails { get; set; }
        public DbSet<ShopClothing.Models.Carts> Carts { get; set; }
        public DbSet<ShopClothing.Models.Cart_item> CartItem { get; set; }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Categories
            modelBuilder.Entity<ShopClothing.Models.Categories>(entity =>
            {
                entity.ToTable("Categories")
                      .HasKey(c => c.CategoryID);
            });

            // Cấu hình bảng Products
            modelBuilder.Entity<ShopClothing.Models.Products>(entity =>
            {
                entity.ToTable("Products")
                      .HasKey(p => p.ProductID);

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryID)
                      .OnDelete(DeleteBehavior.Cascade);
                     
            });

            // Cấu hình bảng Colors
            modelBuilder.Entity<ShopClothing.Models.Colors>(entity =>
            {
                entity.ToTable("Colors")
                      .HasKey(c => c.ColorID);
            });

            // Cấu hình bảng Sizes
            modelBuilder.Entity<ShopClothing.Models.Sizes>(entity =>
            {
                entity.ToTable("Sizes")
                      .HasKey(s => s.SizeID);
            });

            // Cấu hình bảng ColorSizes
            modelBuilder.Entity<ShopClothing.Models.ColorSizes>(entity =>
            {
                entity.ToTable("ColorSizes")
                      .HasKey(cs => cs.ColorSizesID);

                entity.HasOne(cs => cs.Color)
                      .WithMany(c => c.ColorSizes)
                      .HasForeignKey(cs => cs.ColorID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cs => cs.sizes)
                      .WithMany(s => s.ColorSizes)
                      .HasForeignKey(cs => cs.SizeID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cs => cs.Product)
                      .WithMany(p => p.ColorSizes)
                      .HasForeignKey(cs => cs.ProductID)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Cấu hình bảng Orders
            modelBuilder.Entity<ShopClothing.Models.Orders>(entity =>
            {
                entity.ToTable("Orders")
                      .HasKey(o => o.OrderID);

                entity.HasOne(o => o.applicationUser)
                      .WithMany(u => u.Orders)
                      .HasForeignKey(o => o.UserID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Cấu hình bảng OrderDetails
            modelBuilder.Entity<ShopClothing.Models.OrderDetails>(entity =>
            {
                entity.ToTable("OrderDetail")
                      .HasKey(od => od.OrderDetailID);

                entity.HasOne(od => od.Orders)
                      .WithMany(o => o.orderDetails)
                      .HasForeignKey(od => od.OrderID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(od => od.Products)
                      .WithMany(p => p.OrderDetails)
                      .HasForeignKey(od => od.ProductID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(od => od.ColorSizes)
                      .WithMany(cs => cs.OrderDetails)
                      .HasForeignKey(od => od.ColorSizesID)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // Cấu hình bảng Carts
            modelBuilder.Entity<ShopClothing.Models.Carts>(entity =>
            {
                entity.ToTable("Carts")
                      .HasKey(c => c.CartID);
            });

            // Cấu hình bảng Cart_item
            modelBuilder.Entity<ShopClothing.Models.Cart_item>(entity =>
            {
                entity.ToTable("Cart_item")
                      .HasKey(ci => ci.Cart_itemID);

                entity.HasOne(ci => ci.Carts)
                      .WithMany(c => c.cart_Items)
                      .HasForeignKey(ci => ci.CartID)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ci => ci.ColorSizes)
                      .WithMany(cs => cs.cart_Items)
                      .HasForeignKey(ci => ci.ColorSizesID)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(ci => ci.Products)
                      .WithMany(p => p.CartItems)
                      .HasForeignKey(ci => ci.ProductID);
            });
        }
    }
}
