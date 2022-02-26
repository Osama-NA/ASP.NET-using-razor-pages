using ASP.NET_with_razor_pages.Data;
using ASP.NET_with_razor_pages.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_with_razor_pages.Pages.test
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category;
        }
    }
}
