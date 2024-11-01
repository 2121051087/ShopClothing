using ShopClothing.Data;
using ShopClothing.Repositories;
using System.Security.Claims;

namespace ShopClothing.Infrastructure
{
    public class ShopClothingUnitOfWork : IUnitOfWork
    {
        private readonly ShopClothingContext _context;

        public ICartRepository CartRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public IAccountRepository AccountRepository { get; set; }

        public ShopClothingUnitOfWork(ShopClothingContext context, ICartRepository cartRepository, IOrderRepository orderRepository ,ICategoryRepository categoryRepository ,IAccountRepository accountRepository)
        {
            _context = context;
            CartRepository = cartRepository;
            OrderRepository = orderRepository;
            CategoryRepository = categoryRepository;
            AccountRepository = accountRepository;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}