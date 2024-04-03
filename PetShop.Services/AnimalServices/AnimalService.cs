using PetShop.Data.Repositories.AnimalRepository;
using PetShop.Data.Repositories.CommentRepository;
using PetShop.Models;
using PetShop.Models.Filters;

namespace PetShop.Services.AnimalServices
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        private readonly ICommentRepository _commentRepository;

        public AnimalService(IAnimalRepository repository, ICommentRepository commentRepository)
        {
            _repository = repository;
            _commentRepository = commentRepository;
        }

        public async Task InsertAnimal(Animal animal)
        {
            await _repository.InsertAnimal(animal);
        }

        public async Task UpdateAnimal(int id, Animal animal)
        {
            await _repository.UpdateAnimal(id, animal);
        }

        public async Task DeleteAnimal(int id)
        {
            await _repository.DeleteAnimal(id);
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _repository.GetAnimals();
        }

        public async Task<Animal> GetAnimalById(int id)
        {
            return await _repository.GetAnimalById(id);
        }

        public async Task<IEnumerable<Animal>> GetAnimalByCategory(int id)
        {
            return await _repository.GetAnimalByCategory(id);
        }

        public async Task<IEnumerable<HighestRatedAnimals>> GetHighestRatedAnimals()
        {
            var animals = await GetAnimals();

            List<HighestRatedAnimals> tempList = new List<HighestRatedAnimals>();
            foreach (var animal in animals)
            {

                int count = await _commentRepository.GetNumberOfCommentByAnimalId(animal);
                tempList.Add(new HighestRatedAnimals { Animal = animal, RatingCount = count });
            }

            tempList = tempList.OrderByDescending(r => r.RatingCount).ToList();

            var highestRatedAnimalsList = tempList.Take(2);

            return highestRatedAnimalsList;
        }

        public async Task<bool> AnimalIdIsExists(int id)
        {
            return await _repository.AnimalIdIsExists(id);
        }
    }
}
