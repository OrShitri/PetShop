using Microsoft.AspNetCore.Http;
using PetShop.Data.Repositories.AnimalRepository;

namespace PetShop.Services.ImageServices
{
    public class ImageService : IImageService
    {
        private const string RELATIVE_PATH = @"..\petshop.client\wwwroot\images";
        private static string[] AcceptableImageFormats = new[] { ".jpg", ".jpeg", ".png", ".gif" };

        private readonly IAnimalRepository _animalRepository;

        public ImageService(IAnimalRepository repository)
        {
            _animalRepository = repository;
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string extention = Path.GetExtension(imageFile.FileName);
            if (!AcceptableImageFormats.Contains(extention))
                throw new Exception();

            string fileName = $"{Guid.NewGuid()}{extention}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), RELATIVE_PATH, fileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task DeleteImage(int id)
        {
            var animalInDb = await _animalRepository.GetAnimalById(id);

            if (animalInDb.PictureName != null)
            {
                string pathImage = Path.Combine(Directory.GetCurrentDirectory(), RELATIVE_PATH, animalInDb.PictureName);
                File.Delete(pathImage);
            }
        }
    }
}
