
using DemoCRUD.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoCRUD.Data.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Students> Students { get; set; }

    }
}
