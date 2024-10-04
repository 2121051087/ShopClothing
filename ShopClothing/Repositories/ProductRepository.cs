using Microsoft.AspNetCore.Http;
using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopClothingContext _context;
     

        public ProductRepository(ShopClothingContext context)
        {
            _context = context;
        }

        public async Task<Products> AddNewProductAsync(ProductDetailDTO product)
        {
            string base64Image = null!;

            if (product.formFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await product.formFile.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes); // Chuyển thành chuỗi base64
                }
            }


            try
            {
                var newProduct = new Products
                {
                    ProductID = Guid.NewGuid(),

                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price,
                    ImageProduct = base64Image
                };

                
               await _context.Products.AddAsync(newProduct);
               await _context.SaveChangesAsync();

                return newProduct;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, "Error at this point");
                throw;
            }

     
        }

        public Task<Products> UpdateProductAsync(Products product, Guid id)
        {
            throw new NotImplementedException();
        }
        public Task<Guid> DeleteProductAsync(Guid id)
        {
            throw new NotImplementedException();
        }
      
    }
}
