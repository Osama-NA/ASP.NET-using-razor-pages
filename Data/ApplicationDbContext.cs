using ASP.NET_with_razor_pages.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_with_razor_pages.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
    }
}
