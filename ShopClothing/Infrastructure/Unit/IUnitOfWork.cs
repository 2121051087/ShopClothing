using ShopClothing.Infrastructure.Repositories;

namespace ShopClothing.Infrastructure.Unit
{
    public interface IUnitOfWork
    {
        ICartRepository CartRepository { get; set; }

        IOrderRepository OrderRepository { get; set; }

        ICategoryRepository CategoryRepository { get; set; }

        IAccountRepository AccountRepository { get; set; }
        Task SaveChangesAsync();

    }
}
