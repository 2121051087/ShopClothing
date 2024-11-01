using ShopClothing.Repositories;

namespace ShopClothing.Infrastructure
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
