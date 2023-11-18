using Coocing.Interfaces;
using Coocing.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Coocing.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IActionResult> Index()
        {
            var recipes = await _courseRepository.GetAllCourses();
            return View(recipes);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Name)
        {
            var recipes = await _courseRepository.GetCoursesByName(Name);
            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await _courseRepository.GetCourseInfoAsync(id);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Registration(int id)
        {
            return View();
        }

    }
}
