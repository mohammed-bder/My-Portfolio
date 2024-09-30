using Microsoft.AspNetCore.Mvc;
using My_Portfolio.Models;
using MyPortfolio.Models;

namespace My_Portfolio.Controllers
{
    public class SocialController : Controller
    {
        MyContext Context;
        public SocialController(MyContext _context)
        {
            Context = _context;
        }
        public IActionResult Index()
        {
            Social? social = Context.Social.FirstOrDefault();
            if(social == null)
            {
                return Content("No social profile found in the database.");
            }

            return View("Index", social);
        }
    }
}
