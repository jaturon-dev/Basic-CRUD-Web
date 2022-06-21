using BasicCRUDWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUDWeb.Controllers.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Todo> TodoLists { get; set; }
    }
}
