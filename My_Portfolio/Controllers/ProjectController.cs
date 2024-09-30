using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using My_Portfolio.Models;
using My_Portfolio.Repository;
using MyPortfolio.Models;


namespace My_Portfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyContext Context;
        private readonly IProjectRepository projectRepository;

        public ProjectController(MyContext _context , IProjectRepository projectRepository)
        {
            Context = _context;
            this.projectRepository = projectRepository;
        }
        public IActionResult Index()
        {
            List<Project> projects = projectRepository.GetAll();
            if(projects == null || !projects.Any())
            {
                return Content("Projects Not Found");
            }
            return View("Index", projects);
        }

        // ************** Add Services **************
        public IActionResult Add()
        {
            return View(new Project());
        }

        // ************** Save Services info **************
        [HttpPost]
        public IActionResult SaveAdd(Project project, IFormFile SrcImage)
        {
            if (ModelState.IsValid)
            {
                
                if (SrcImage != null && SrcImage.Length > 0)
                {
                    
                    var fileName = Path.GetFileName(SrcImage.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        SrcImage.CopyTo(fileStream);
                    }
  
                    project.SrcImage = "/images/" + fileName;
                }
                
                projectRepository.Add(project);
                projectRepository.Save();

                return RedirectToAction("Index");
            }

            return View("Add", project);
        }


        public IActionResult ViewOfRemove()
        {
            var projectNames = projectRepository.GetAll();
            
            return View(projectNames);
        }

        [HttpPost]
        public IActionResult Delete(string Name)
        {
            Project project = projectRepository.GetByName(Name);

            if (project != null)
            {
                projectRepository.Delete(project);
                projectRepository.Save();

                return RedirectToAction("Index");
            }
            return Content($"Project with name '{Name}' not found.");
        }
    }
}
