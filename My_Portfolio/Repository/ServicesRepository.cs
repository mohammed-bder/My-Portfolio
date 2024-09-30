using My_Portfolio.Models;
using MyPortfolio.Models;

namespace My_Portfolio.Repository
{
    public class ServicesRepository : IServicesRepository
    {
        MyContext Context;
        public ServicesRepository(MyContext _Context)
        {
              Context = _Context;
        }
        public void Add(Services services)
        {
            Context.Add(services);
        }
        public void Update(Services services)
        {
            Context.Update(services);
        }

        public void Delete(Services services)
        {
            Context.Remove(services);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public List<Services> GetAll()
        {
           return Context.Services.ToList();  
        }
        public Services? GetByName(string Title)
        {
            return Context.Services.FirstOrDefault(i => i.Title == Title);
        }

    }
}
