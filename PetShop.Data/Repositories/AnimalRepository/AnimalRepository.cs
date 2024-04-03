using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShop.Data.Repositories.AnimalRepository
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly MyContext _myContext;

        public AnimalRepository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public async Task InsertAnimal(Animal animal)
        {
            await _myContext.Animals!.AddAsync(animal);
            await _myContext.SaveChangesAsync();
        }

        public async Task UpdateAnimal(int id, Animal animal)
        {
            var animalInDb = await GetAnimalById(id);
            animalInDb.Name = animal.Name;
            animalInDb.Age = animal.Age;
            animalInDb.PictureName = animal.PictureName;
            animalInDb.Description = animal.Description;
            animalInDb.CategoryId = animal.CategoryId;
            await _myContext.SaveChangesAsync();
        }

        public async Task DeleteAnimal(int id)
        {
            var animalInDb = await GetAnimalById(id);
            _myContext.Animals!.Remove(animalInDb);
            await _myContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _myContext.Animals!.ToListAsync();
        }

        public async Task<Animal> GetAnimalById(int id)
        {
            return await _myContext.Animals!.SingleAsync(a => a.AnimalId == id);
        }

        public async Task<IEnumerable<Animal>> GetAnimalByCategory(int id)
        {
            return await _myContext.Animals!.Where(m => m.CategoryId == id).ToListAsync();
        }

        public async Task<bool> AnimalIdIsExists(int id)
        {
            return await _myContext.Animals!.AnyAsync(a => a.AnimalId == id);
        }
    }
}
