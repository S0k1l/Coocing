using Coocing.Interfaces;
using Coocing.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Coocing.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipesRepository _recipesRepository;
        private readonly IComentsRepository _comentsRepository;

        public RecipesController(IRecipesRepository recipesRepository, IComentsRepository comentsRepository)
        {
            _recipesRepository = recipesRepository;
            _comentsRepository = comentsRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipesRepository.GetAllRecipesAsync();
            return View(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Name)
        {
            var recipes = await _recipesRepository.GetRecipesByName(Name);
            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var recipes = await _recipesRepository.GetRecipesInfoAsync(id);
            var coments = await _comentsRepository.GetAllComentsAsync(id);
            var model = new RecipesDetailsViewModel
            {
                Recipes = recipes,
                Coments = coments,
            };
            return View(model);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, RecipesViewModel model)
        {
            return View();
        }


    }
}
