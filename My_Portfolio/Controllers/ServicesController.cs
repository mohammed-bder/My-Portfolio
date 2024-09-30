using Microsoft.AspNetCore.Mvc;
using My_Portfolio.Models;
using My_Portfolio.Repository;
using MyPortfolio.Models;
using NuGet.Protocol.Core.Types;

namespace My_Portfolio.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServicesRepository servicesRepository;

        public ServicesController(MyContext _context , IServicesRepository servicesRepository)
        {
            this.servicesRepository = servicesRepository;
        }
        public IActionResult Index()
        {
            List<Services> services = servicesRepository.GetAll();
            if (services == null || !services.Any())
            {
                return Content("No services found.");
            }

            return View("Index", services);
        }

        // ************** Add Services **************
        public IActionResult Add()
        {
            return View(new Services());
        }

        // ************** Save Add Services info **************
        [HttpPost]
        public IActionResult SaveAdd(Services services)
        {

            if (ModelState.IsValid)
            {
                servicesRepository.Add(services);
                servicesRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Add", services);
        }

        public IActionResult ViewOfRemove()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(string Title)
        {
            Services services = servicesRepository.GetByName(Title);

            if (services != null)
            {
                servicesRepository.Delete(services);
                servicesRepository.Save();

                return RedirectToAction("Index");
            }
            return Content($"Service with title '{Title}' not found.");
        }

        // ************** Search Service by Title **************
        public IActionResult Search()
        {
            return View(); 
        }

        // ************** Redirect to Edit Service **************
        [HttpPost]
        public IActionResult SearchByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                ModelState.AddModelError(string.Empty, "Please enter a title.");
                return View("Search"); 
            }

            var service = servicesRepository.GetByName(title);
            if (service == null)
            {
                ModelState.AddModelError(string.Empty, "Service not found.");
                return View("Search"); 
            }

            return RedirectToAction("Edit", new { Title = service.Title }); 
        }

        // ************** Edit Service by Title **************
        public IActionResult Edit(string Title)
        {
            var service = servicesRepository.GetByName(Title);
            if (service == null)
            {
                return NotFound();
            }
            return View("Edit", service);
        }

        // ************** Save Edit Service **************
        [HttpPost]
        public IActionResult SaveEdit(Services service)
        {
            if (ModelState.IsValid)
            {
                servicesRepository.Update(service);
                servicesRepository.Save();
                return RedirectToAction("Index");
            }
            return View("Edit", service);
        }
    }
}

