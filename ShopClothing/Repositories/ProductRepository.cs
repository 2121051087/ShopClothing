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
                    base64Image = Convert.ToBase64String(imageBytes);
                }
            }

            try
            {
                // Tạo mới sản phẩm
                var newProduct = new Products
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price,
                    ImageProduct = base64Image,
                    CategoryID = product.CategoryID 
                };

                
                await _context.Products.AddAsync(newProduct);
                await _context.SaveChangesAsync();

              
                if (product.colorSizesDTO != null && product.colorSizesDTO.Count > 0)
                {
                    var colorSizesList = new List<ColorSizes>(); 
                    foreach (var item in product.colorSizesDTO)
                    {
                        var colorSizes = new ColorSizes
                        {
                            ColorSizesID = Guid.NewGuid(),
                            ProductID = newProduct.ProductID,
                            ColorID = item.ColorID,
                            SizeID = item.SizeID,
                            Quantity = item.Quantity
                        };

                        colorSizesList.Add(colorSizes); 
                    }

           
                    await _context.ColorSizes.AddRangeAsync(colorSizesList);
                    await _context.SaveChangesAsync(); 
                }

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
