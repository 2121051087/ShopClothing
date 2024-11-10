using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Infrastructure.Repositories
{
    public interface IProductRepository
    {

        public Task<Products> AddNewProductAsync(ProductDetailDTO product, string? base64Image);

        public Task<Products> UpdateProductAsync(Products product, int id);

        public Task<int> DeleteProductAsync(int id);

        public Task<List<Products>> GetAllProductAsync(string? search, double? from, double? to, string? SortBy, string? categoryName, int page);

    }
}
