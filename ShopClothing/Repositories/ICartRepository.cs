using ShopClothing.Models;
using System.Runtime.InteropServices;

namespace ShopClothing.Repositories
{
    public interface ICartRepository
    {
        // 
       public Task<Carts> GetCartByIdAsync(int cartId);
       public Task<Carts> GetCartByUserIdAsync(string userId);
       public Task DeleteCartAsync(int cartId);
       public Task<IEnumerable<Cart_item>> GetCartItemsAsync(int cartId);
        // 
       public Task AddCartAsync(Carts cart);
       public  Task UpdateCartAsync(Carts cart);
       public Task AddItemToCartAsync(Cart_item cartItem);
       public Task RemoveItemFromCartAsync(int cartItemId);
     
    }
}
