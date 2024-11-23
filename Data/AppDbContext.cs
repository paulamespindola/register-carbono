using Microsoft.EntityFrameworkCore;
using register_caborno.Models;

namespace register_caborno.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
       

    }
}
