using Azure;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Data;
using ShopClothing.Models;
using System.Security.Claims;
using System.Text;

namespace ShopClothing.Repositories
{
    public class CartsRepository : ICartRepository
    {
        private readonly ShopClothingContext _context;
        private readonly ClaimsPrincipal _user;
        public CartsRepository(ShopClothingContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = httpContextAccessor.HttpContext?.User;
        }
        
        // lay hoac tao gio hang moi
        public async Task<Carts> GetOrCreateCartAsync(string userId)
        {
            var existingCart = await _context.Carts
                                                   .Include(c => c.cart_Items)
                                                   .ThenInclude(ci => ci.Products)
                                                   .FirstOrDefaultAsync(c => c.UserID == userId);

            if (existingCart != null)
              {
                return existingCart;
              }

            var newCart = new Carts
            {
                UserID = userId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Carts.Add(newCart);
            await _context.SaveChangesAsync();
            return newCart;
        }

        public async Task AddItemToCartAsync(CartItemDTO model)
        {

            // Lấy UserID từ ClaimsPrincipal
            var userIdClaim =  _user.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

            //var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userId);

            // Tự động lấy CartID từ giỏ hàng của người dùng hoặc tạo mới nếu chưa có
            var cart = await GetOrCreateCartAsync(userId);
            
            var existingCart = await _context.CartItem.Include(c => c.ColorSizes).FirstOrDefaultAsync(c => c.ProductID == model.ProductID && c.ColorSizesID == model.ColorSizesID);


            if (existingCart != null)
            {
                existingCart.Quantity += model.Quantity;
                existingCart.UpdatedAt = DateTime.UtcNow;

                if (CheckQuantity(existingCart))
                {
                    _context.CartItem.Update(existingCart);
                }
                else
                {
                    throw new Exception("Số lượng vượt quá tồn kho.");
                }
            }
            else
            {
                var newCartItem = new Cart_item
                {
                    
                    CartID = cart.CartID,
                    ProductID = model.ProductID,
                    ColorSizesID = model.ColorSizesID,
                    Quantity = model.Quantity,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                if (CheckQuantity(newCartItem))
                {
                    _context.CartItem.Add(newCartItem);
                }
                else
                {
                    throw new Exception("Số lượng vượt quá tồn kho.");
                }
            }
            await _context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(int cartItemId)
        {
           var cartItem = _context.CartItem.FirstOrDefault(c => c.Cart_itemID == cartItemId);
            if(cartItem == null)
            {
                return;
            }
            _context.CartItem.Remove(cartItem);
            await _context.SaveChangesAsync();
        }

        private  bool CheckQuantity(Cart_item item)  
        {
            if (item.ColorSizesID == null)
            {
                throw new ArgumentNullException("ID san pham ko ton tai");
            }
            if (item.Quantity <= 0)
            {
                throw new ArgumentOutOfRangeException("Số lượng sản phẩm không hợp lệ.");
            }

            var colorSizes = _context.ColorSizes.FirstOrDefault(cs => cs.ColorSizesID == item.ColorSizesID);
            // Check for null before accessing ColorSizes.Quantity
            return colorSizes.Quantity >= item.Quantity; 
        }

        // -------------------------------------------------------

        public async Task<bool> UpdateCartItemAsync(int cartItemId, Dictionary<string, object> updates)
        {
            var existingCartItem = await GetCartItemByIdAsync(cartItemId);
            if (existingCartItem != null)
            {
                // Cập nhật trường Quantity nếu có trong updates
                if (updates.ContainsKey("quantity"))
                    existingCartItem.Quantity = Convert.ToInt32(updates["quantity"]);

                // Cập nhật thời gian chỉnh sửa
                existingCartItem.UpdatedAt = DateTime.UtcNow;

                _context.CartItem.Update(existingCartItem);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<Cart_item> GetCartItemByIdAsync(int cartItemId)
        {
            return await _context.CartItem.FindAsync(cartItemId);
        }

      

        public async Task ClearCart()
        {
            var userIdClaim = _user.FindFirst(ClaimTypes.NameIdentifier);
            var userId = userIdClaim?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }

         
            var existCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserID == userId);


            var CartItem = _context.CartItem.Where(ci => ci.CartID == existCart.CartID);

            _context.CartItem.RemoveRange(CartItem);

            await _context.SaveChangesAsync();
        }
    }
}
