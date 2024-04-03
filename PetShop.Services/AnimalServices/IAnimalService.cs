using PetShop.Models;
using PetShop.Models.Filters;

namespace PetShop.Services.AnimalServices
{
    public interface IAnimalService
    {
        Task InsertAnimal(Animal animal);

        Task UpdateAnimal(int id, Animal animal);

        Task DeleteAnimal(int id);

        Task<IEnumerable<Animal>> GetAnimals();

        Task<Animal> GetAnimalById(int id);

        Task<IEnumerable<Animal>> GetAnimalByCategory(int id);

        Task<IEnumerable<HighestRatedAnimals>> GetHighestRatedAnimals();

        Task<bool> AnimalIdIsExists(int id);
    }
}
