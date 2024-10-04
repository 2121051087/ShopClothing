using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public interface IProductRepository
    {
     
        public Task<Products> AddNewProductAsync(ProductDetailDTO product);

        public Task<Products> UpdateProductAsync(Products product, Guid id);

        public Task<Guid> DeleteProductAsync(Guid id);
        
    }
}
