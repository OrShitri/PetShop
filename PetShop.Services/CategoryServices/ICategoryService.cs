using PetShop.Models;

namespace PetShop.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<Category> GetCategoryById(int id);

        Task<bool> CategoryIdIsExists(int id);
    }
}
