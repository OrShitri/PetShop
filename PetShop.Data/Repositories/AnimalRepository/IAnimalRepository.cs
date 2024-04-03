using PetShop.Models;

namespace PetShop.Data.Repositories.AnimalRepository
{
    public interface IAnimalRepository
    {
        Task InsertAnimal(Animal animal);

        Task UpdateAnimal(int id, Animal animal);

        Task DeleteAnimal(int id);

        Task<IEnumerable<Animal>> GetAnimals();

        Task<Animal> GetAnimalById(int id);

        Task<IEnumerable<Animal>> GetAnimalByCategory(int id);

        Task<bool> AnimalIdIsExists(int id);
    }
}
