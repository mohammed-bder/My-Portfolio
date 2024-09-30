using Microsoft.AspNetCore.Mvc;

namespace My_Portfolio.Controllers
{
    public class ResumeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
