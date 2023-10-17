using Microsoft.AspNetCore.Mvc;

namespace AncientRelicQuest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}