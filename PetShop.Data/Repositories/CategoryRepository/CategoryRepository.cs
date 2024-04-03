using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyContext _myContext;

        public CategoryRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _myContext.Categories!.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _myContext.Categories!.SingleAsync(m => m.CategoryId == id);
        }

        public async Task<bool> CategoryIdIsExists(int id)
        {
            return await _myContext.Categories!.AnyAsync(m => m.CategoryId == id);
        }
    }
}
