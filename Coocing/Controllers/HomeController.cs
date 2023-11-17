using Coocing.Interfaces;
using Coocing.Models;
using Coocing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coocing.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipesRepository _recipesRepository;
        private readonly ICourseRepository _courseRepository;

        public HomeController(ILogger<HomeController> logger,
            IRecipesRepository recipesRepository,
            ICourseRepository courseRepository)
        {
            _logger = logger;
            _recipesRepository = recipesRepository;
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var recipes = await _recipesRepository.GetAllRecipesAsync();
            var courses = await _courseRepository.GetAllCourses();
            var model = new HomeViewModel { Recipes = recipes, Courses = courses};
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}