using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Services.AnimalServices;
using System.Diagnostics;

namespace PetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimalService _animalService;
        public HomeController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _animalService.GetHighestRatedAnimals());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}