using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public interface IOrderRepository
    {
        public Task CreateOrderAsync(OrdersDTO model);
        public Task<IEnumerable<Orders>> GetOrdersByUserIdAsync(string userId);
        public Task<Orders> GetOrderByIdAsync(int orderId);
        public Task UpdateOrderStatusAsync(int orderId, string status);

    }
}
