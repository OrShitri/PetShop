using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services.AnimalServices;
using PetShop.Services.CategoryServices;
using PetShop.Services.CommentServices;
using PetShop.Services.ImageServices;
using System.ComponentModel.DataAnnotations;

namespace PetShop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly IImageService _imageService;

        public AdminController(IAnimalService animalService, ICategoryService categoryService, ICommentService commentService, IImageService imageService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
            _commentService = commentService;
            _imageService = imageService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Catalog", new { page = "Admin" });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AddAnimal()
        {
            ViewBag.Categories = await _categoryService.GetCategories();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertAnimal(Animal animal, IFormFile? imageFile) 
        {
            if (ModelState.IsValid && await _categoryService.CategoryIdIsExists(animal.CategoryId))
            {
                try
                {
                    if (imageFile != null)
                        animal.PictureName = await _imageService.SaveImage(imageFile);

                    await _animalService.InsertAnimal(animal);
                    return RedirectToAction("Details", "Catalog", new { id = animal.AnimalId, page = "Admin" });
                }
                catch (Exception)
                {
                    return StatusCode(404);
                }
                
            }

            return StatusCode(404);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditAnimal(int id)
        {
            try
            {
                var animal = await _animalService.GetAnimalById(id);
                ViewBag.CategoryName = await _categoryService.GetCategoryById(animal.CategoryId);
                ViewBag.Categories = await _categoryService.GetCategories();
                return View(animal);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateAnimal(Animal animal, IFormFile? imageFile) 
        {
            if (ModelState.IsValid && await _categoryService.CategoryIdIsExists(animal.CategoryId) && await _animalService.AnimalIdIsExists(animal.AnimalId))
            {
                try
                {
                    if (imageFile != null)
                    {
                        animal.PictureName = await _imageService.SaveImage(imageFile);
                        await _imageService.DeleteImage(animal.AnimalId);
                    }

                    await _animalService.UpdateAnimal(animal.AnimalId, animal);
                    return RedirectToAction("EditAnimal", new { id = animal.AnimalId });
                }
                catch (Exception)
                {
                    return StatusCode(404);
                }
               
            }

            return StatusCode(404);
        }

        [Authorize]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            try
            {
                await _imageService.DeleteImage(id);
                await _commentService.RemoveAllComments(id);
                await _animalService.DeleteAnimal(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditComment(int id, [StringLength(500)][Required][MinLength(4)] string comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int animalId = await _commentService.GetAnimalIdByCommentId(id);
                    await _commentService.EditComment(id, comment);
                    return RedirectToAction("Details", "Catalog", new { id = animalId, page = "Admin" });
                }

                return StatusCode(404);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

        [Authorize]
        public async Task<IActionResult> RemoveComment(int id)
        {
            try
            {
                int animalId = await _commentService.GetAnimalIdByCommentId(id);
                await _commentService.RemoveComment(id);
                return RedirectToAction("Details", "Catalog", new { id = animalId, page = "Admin" });
            }
            catch (Exception)
            {
                return StatusCode(404);
            }
        }

    }
}
