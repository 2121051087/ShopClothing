using ShopClothing.Data;
using ShopClothing.Models;

namespace ShopClothing.Repositories
{
    public interface ICategoryRepository
    {
        Task <IEnumerable<Categories>> GetAllCategories();

        Task<Categories> AddNewCategory(Categories category);

        Task<Categories> UpdateCategory(Categories category , string id);

        Task<Categories> DeleteCategory( string id);
    }
}
