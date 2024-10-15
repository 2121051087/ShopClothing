using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public class CartsRepository : ICartRepository
    {
        private readonly ShopClothingContext _context;
        public CartsRepository(ShopClothingContext context)
        {
            _context = context; 
        }
        public async Task AddCartAsync(Carts cart)
        {
            await  _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
        }

        public Task AddItemToCartAsync(Cart_item cartItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCartAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Carts> GetCartByIdAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task<Carts> GetCartByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Cart_item>> GetCartItemsAsync(int cartId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItemFromCartAsync(int cartItemId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCartAsync(Carts cart)
        {
            throw new NotImplementedException();
        }
    }
}
