using Microsoft.AspNetCore.Http;

namespace PetShop.Services.ImageServices
{
    public interface IImageService
    {
        Task<string> SaveImage(IFormFile imageFile);

        Task DeleteImage(int id);
    }
}
