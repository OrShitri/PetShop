using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Services.AnimalServices;
using PetShop.Services.CategoryServices;
using PetShop.Services.CommentServices;

namespace PetShop.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        public CatalogController(IAnimalService animalService, ICategoryService categoryService, ICommentService commentService)
        {
            _animalService = animalService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index(string page)
        {
            ViewBag.Page = page;
            ViewBag.Categories = await _categoryService.GetCategories();
            return View(await _animalService.GetAnimals());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string page)
        {
            try
            {
                ViewBag.Page = page;
                var animal = await _animalService.GetAnimalById(id);
                ViewBag.CategoryName = await _categoryService.GetCategoryById(animal.CategoryId);
                ViewBag.Comments = await _commentService.GetComment(id);
                return View(animal);
            }
            catch (Exception)
            {
                return StatusCode(404);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (ModelState.IsValid && await _animalService.AnimalIdIsExists(comment.AnimalId))
            {
                await _commentService.AddComment(comment); 
                return RedirectToAction("Details", new { id = comment.AnimalId });
            }

            return StatusCode(404);
        }

        [HttpPost]
        public async Task<IActionResult> ShowCategoty(int categoryId, string page)
        {
            if (categoryId == 0)
            {
                if (page == "Admin")
                    return RedirectToAction("Index", new { page = page });
                else
                    return RedirectToAction("Index");
            }

            ViewBag.Page = page;
            ViewBag.Categories = await _categoryService.GetCategories();
            return View("Index", await _animalService.GetAnimalByCategory(categoryId));
        }
    }
}
