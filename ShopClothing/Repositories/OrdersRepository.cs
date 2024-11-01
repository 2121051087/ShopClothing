using Microsoft.EntityFrameworkCore;
using ShopClothing.Data;
using ShopClothing.Models;
using System.Security.Claims;

namespace ShopClothing.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly ShopClothingContext _context;
        private readonly ClaimsPrincipal? _user;
        private readonly ICartRepository _repo;
        private readonly IAccountRepository _accountRepository;

        public OrdersRepository(ShopClothingContext context, IHttpContextAccessor httpContextAccessor , ICartRepository repo , IAccountRepository accountRepository)
        {
            _context = context;
            _user = httpContextAccessor.HttpContext?.User;
            _repo = repo;
            _accountRepository = accountRepository;
        }

     
        public async Task CreateOrderAsync(OrdersDTO model)
        {
           var userId = _accountRepository.GetUserId();
            // Set thông tin cơ bản cho đơn hàng
            var order = new Orders
            {
                UserID = userId,
                Status = "Pending",
                OrderDate = DateTime.UtcNow,
                TotalAmount = model.TotalAmount,
                Address = model.Address,
                City = model.City,
                District = model.District,
                Ward = model.Ward,
                PhoneNumber = model.PhoneNumber
            };

            var existCart = await _repo.GetOrCreateCartAsync(userId);
                if (existCart == null)
                {
                    throw new InvalidOperationException("Cart not found.");
                }

                // Lấy các mục trong giỏ hàng và thông tin sản phẩm
                var cartItems = _context.CartItem.Include(ci => ci.Products)
                    .Where(ci => ci.CartID == existCart.CartID)
                    .ToList();

            var orderDetails = new List<OrderDetails>();
            foreach (var cartItem in cartItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductID == cartItem.ProductID);
                if (product == null)
                {
                    throw new InvalidOperationException("Product not found.");
                }

                // tru so luong san pham khi tao don 
                var colorSizes = await _context.ColorSizes.FirstOrDefaultAsync(cs => cs.ColorSizesID == cartItem.ColorSizesID);
                colorSizes.Quantity -= cartItem.Quantity;
                    

                orderDetails.Add(new OrderDetails
                {
                    OrderID = order.OrderID,
                    ProductID = cartItem.ProductID,
                    ColorSizesID = cartItem.ColorSizesID,
                    Quantity = cartItem.Quantity,
                    Price = product.Price,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }

            order.orderDetails = orderDetails;

            await _context.Orders.AddAsync(order);

            

        }

       

        public Task<Orders> GetOrderByIdAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderStatusAsync(int orderId, string status)
        {
            throw new NotImplementedException();
        }
    }
}
