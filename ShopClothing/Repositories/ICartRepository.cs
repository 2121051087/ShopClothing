using ShopClothing.Data;
using ShopClothing.Models;
using System.Runtime.InteropServices;

namespace ShopClothing.Repositories
{
    public interface ICartRepository
    {
        // 
       public Task<Carts> GetCartByIdAsync(int cartId);
       public Task<Carts> GetOrCreateCartAsync(string userId);
       public Task DeleteCartAsync(int cartId);
       public Task<IEnumerable<Cart_item>> GetCartItemsAsync(int cartId);
        // 
  
       public  Task UpdateCartAsync(Carts cart);
       public Task AddItemToCartAsync(CartItemDTO model);
       public Task RemoveItemFromCartAsync(int cartItemId);
     
    }
}
