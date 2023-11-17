using Coocing.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Coocing.Controllers
{
    public class RecipesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult MyRecipes()
        {
            return View(null);
        }

        [HttpGet]
        public IActionResult CreateRecipe()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateRecipe(RecipesViewModel model)
        {

            return View();
        }
    }
}
