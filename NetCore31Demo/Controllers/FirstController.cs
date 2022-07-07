using Microsoft.AspNetCore.Mvc;

namespace NetCore31Demo.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
