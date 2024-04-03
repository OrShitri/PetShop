using PetShop.Data.Repositories.CategoryRepository;
using PetShop.Models;

namespace PetShop.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _repository.GetCategories();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _repository.GetCategoryById(id);
        }

        public async Task<bool> CategoryIdIsExists(int id)
        {
           return await _repository.CategoryIdIsExists(id);
        }
    }
}
