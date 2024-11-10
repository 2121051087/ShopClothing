using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Data;
using ShopClothing.Infrastructure.Data;
using ShopClothing.Models;

namespace ShopClothing.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopClothingContext _context;

        public static int Page_Size { get; set; } = 5;

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
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
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

        public Task<Products> UpdateProductAsync(Products product, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return 0;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return id;


        }

        public async Task<List<Products>> GetAllProductAsync(string? search, double? from, double? to, string? sortBy, string? categoryName, int page = 1)
        {
            var allProducts = _context.Products.AsQueryable();

            #region Filtering

            // Tìm kiếm theo tên sản phẩm hoặc ID
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(p => p.ProductName.Contains(search) || p.ProductID.ToString().Contains(search));
            }

            // Lọc theo danh mục
            if (!string.IsNullOrEmpty(categoryName))
            {
                allProducts = from p in allProducts
                              join c in _context.Categories
                              on p.CategoryID equals c.CategoryID
                              where c.CategoryName == categoryName
                              select p;
            }

            // Lọc theo khoảng giá
            if (from.HasValue)
            {
                allProducts = allProducts.Where(p => p.Price >= from.Value);
            }

            if (to.HasValue)
            {
                allProducts = allProducts.Where(p => p.Price <= to.Value);
            }

            #endregion

            #region Sorting

            // Sắp xếp theo tiêu chí
            allProducts = sortBy switch
            {
                "Price" => allProducts.OrderBy(p => p.Price),
                "PriceDesc" => allProducts.OrderByDescending(p => p.Price),
                _ => allProducts.OrderBy(p => p.ProductID) // Mặc định sắp xếp theo ProductID
            };

            #endregion

            #region Paging


            allProducts = allProducts.Skip((page - 1) * Page_Size).Take(Page_Size);

            #endregion

            // Lấy danh sách sản phẩm
            var result = await allProducts.Select(p => new Products
            {
                ProductID = p.ProductID,
                ProductDescription = p.ProductDescription,
                ProductName = p.ProductName,
                Price = p.Price,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt,
                ImageProduct = p.ImageProduct,
                CategoryID = p.CategoryID,
                ColorSizes = p.ColorSizes
            }).ToListAsync();

            return result;
        }




    }
}
