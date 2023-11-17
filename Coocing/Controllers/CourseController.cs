using Microsoft.AspNetCore.Mvc;

namespace Coocing.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
