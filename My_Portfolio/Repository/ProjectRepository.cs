using My_Portfolio.Models;
using MyPortfolio.Models;

namespace My_Portfolio.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        MyContext Context;
        public ProjectRepository(MyContext _Context)
        {
            Context = _Context;
        }
        public void Add(Project project)
        {
            Context.Add(project);
        }
        public void Update(Project project)
        {
            Context.Update(project);
        }

        public void Delete(Project project)
        {
            Context.Remove(project);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public List<Project> GetAll()
        {
            return Context.Projects.ToList();
        }
        public Project GetByName(string Name)
        {
            return Context.Projects.FirstOrDefault(i => i.Name == Name);
        }
    }
}
