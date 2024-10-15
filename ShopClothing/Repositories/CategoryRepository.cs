using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ShopClothing.Data;
using ShopClothing.Models;


namespace ShopClothing.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ShopClothingContext _context;

        public CategoryRepository(ShopClothingContext context)
        {
            _context = context;
        }
        public  async Task<IEnumerable<Categories>> GetAllCategories()
        {

            var categories = await _context.Categories.ToListAsync();
            return categories;

        }
      
        public async Task<Categories> AddNewCategory(Categories category)
        {
           await _context.Categories.AddAsync(category);
           await _context.SaveChangesAsync();
           return category;
        }

        public async Task<Categories> UpdateCategory(Categories category , string id)
        {
          
           _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(int id)
        {
           
            var deleteCategory = await _context.Categories.SingleOrDefaultAsync(x => x.CategoryID == id);

            if (deleteCategory != null)
            {
               _context.Categories.Remove(deleteCategory);
                await _context.SaveChangesAsync();
            }

        }


    }
}
