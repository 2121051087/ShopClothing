using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly ShopClothingContext _context;

        public OrdersRepository(ShopClothingContext context)
        {
            _context = context;
        }

        public async Task CreateOrderAsync(Orders order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

        }

    }
}
