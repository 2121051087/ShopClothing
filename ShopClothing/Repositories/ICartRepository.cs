using ShopClothing.Data;
using ShopClothing.Models;
using System.Runtime.InteropServices;

namespace ShopClothing.Repositories
{
    public interface ICartRepository
    {
        // 
       public Task<Cart_item> GetCartItemByIdAsync(int cartItemId);
  
       public Task<Carts> GetOrCreateCartAsync(string userId);
     
       public Task<bool> UpdateCartItemAsync(int cartItemId, Dictionary<string, object> updates);
       public Task AddItemToCartAsync(CartItemDTO model);
       public Task RemoveItemFromCartAsync(int cartItemId);
     
    }
}
