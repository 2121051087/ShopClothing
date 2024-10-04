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
           var newCategory = new Categories
           {
               CategoryID = Guid.NewGuid(),
               CategoryName = category.CategoryName
           };

           await _context.Categories.AddAsync(newCategory);
           await _context.SaveChangesAsync();
           return newCategory;
        }

        public async Task<Categories> UpdateCategory(Categories category , string id)
        {
          if(id != category.CategoryID.ToString())
          {
              return null;
          }
           _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Categories> DeleteCategory(string id)
        {
            
            var category = await _context.Categories.FindAsync(Guid.Parse(id));

            if(category == null)
            {
                return null;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return category;
            
        }

    }
}
