using Microsoft.AspNetCore.Mvc;

namespace My_Portfolio.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Phone = "+02 111 839 1368";
            ViewBag.Email = "mohasanbder@gmail.com";
            return View();
        }
    }
}
