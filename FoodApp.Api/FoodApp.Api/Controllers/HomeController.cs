using Microsoft.AspNetCore.Mvc;

namespace FoodApp.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("API is working");
        }
    }
}