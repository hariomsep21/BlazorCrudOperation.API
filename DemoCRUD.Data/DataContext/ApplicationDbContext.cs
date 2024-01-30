
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
        public DbSet<Gender> tblGender { get; set; }

        public DbSet<State> tblState { get; set; }


    }
}
