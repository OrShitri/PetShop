using PetShop.Models;

namespace PetShop.Data.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategoryById(int id);

        Task<bool> CategoryIdIsExists(int id);
    }
}
