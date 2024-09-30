using Microsoft.EntityFrameworkCore;
using MyPortfolio.Models;

namespace My_Portfolio.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Social> Social { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public MyContext() : base()
        {

        }
        public MyContext(DbContextOptions options) : base(options)
        {

        }
    }
}
