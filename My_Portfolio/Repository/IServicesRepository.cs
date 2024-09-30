using MyPortfolio.Models;

namespace My_Portfolio.Repository
{
    public interface IServicesRepository : IRepository<Services>
    {
        Services GetByName(string Title);
    }
}
