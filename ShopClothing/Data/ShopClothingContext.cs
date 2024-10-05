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

                // Cấu hình quan hệ one-to-many
                entity.HasOne(p => p.Category) 
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryID);


            });
            modelBuilder.Entity<ShopClothing.Models.Colors>(entity =>
            {
                entity.ToTable("Colors")
                      .HasKey(c => c.ColorID);

                
            });
            modelBuilder.Entity<ShopClothing.Models.Sizes>(entity =>
            {
                entity.ToTable("Sizes")
                      .HasKey(s => s.SizeID);

               
            });
            modelBuilder.Entity<ShopClothing.Models.ColorSizes>(entity =>
            {
                entity.ToTable("ColorSizes")
                      .HasKey(cs => cs.ColorSizesID);

                
                entity.HasOne(cs => cs.Color)
                      .WithMany(c => c.ColorSizes)
                      .HasForeignKey(cs => cs.ColorID); 
              

                entity.HasOne(cs => cs.sizes) 
                      .WithMany(s => s.ColorSizes) 
                      .HasForeignKey(cs => cs.SizeID); 

                entity.HasOne(cs => cs.Product)      // Mỗi ColorSize thuộc về một Product
                      .WithMany(p => p.ColorSizes)   // Một Product có nhiều ColorSizes
                      .HasForeignKey(cs => cs.ProductID) // Đặt ProductID làm khóa ngoại
                      .OnDelete(DeleteBehavior.Cascade); // Khi Product bị xóa, ColorSizes cũng bị xóa
            });
         
        }

    }
}
