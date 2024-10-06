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

        public async Task<Products> AddNewProductAsync(ProductDetailDTO product, string? base64Image)
        {
            try
            {
                var newProduct = new Products
                {
                    ProductName = product.ProductName,
                    ProductDescription = product.ProductDescription,
                    Price = product.Price,
                    ImageProduct = base64Image!,
                    CategoryID = product.CategoryID
                };

                await _context.Products.AddAsync(newProduct);
                await _context.SaveChangesAsync();

                List<ColorSidesDTO> colorSizesDTO;
                try
                {
                    colorSizesDTO = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ColorSidesDTO>>(product.colorSizesDTO);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi chuyển đổi JSON: " + ex.Message);
                    throw new Exception("Dữ liệu ColorSizesDTO không hợp lệ.");
                }
                foreach (var item in colorSizesDTO)
                {
                    var colorSizes = new ColorSizes
                    {
                        ProductID = newProduct.ProductID,
                        ColorID = item.ColorID,
                        SizeID = item.SizeID,
                        Quantity = item.Quantity
                    };
                    await _context.ColorSizes.AddAsync(colorSizes);
                }
            
                await _context.SaveChangesAsync();
               
                return newProduct;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
