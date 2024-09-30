using MyPortfolio.Models;

namespace My_Portfolio.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Project GetByName(string Name);
    }
}
