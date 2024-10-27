using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public interface IOrderRepository
    {
        public interface IOrderRepository
        {
           public Task CreateOrderAsync(Orders order);
           public Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(string userId);
           public Task<Orders> GetOrderByIdAsync(int orderId);
           public Task UpdateOrderStatusAsync(int orderId, string status);
           public Task ClearCartAsync(int cartId);
        }


    }
}
