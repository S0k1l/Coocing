using Microsoft.AspNetCore.Mvc;

namespace Coocing.Controllers
{
    public class RecipesController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
