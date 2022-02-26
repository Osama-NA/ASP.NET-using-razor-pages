using ASP.NET_with_razor_pages.Data;
using ASP.NET_with_razor_pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_with_razor_pages.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty] //Or use global [BindProperties] if more than one property used in UI
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);
        }
        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _db.Category.Find(Category.Id);

            if (categoryFromDb != null)
            {
                _db.Category.Remove(categoryFromDb);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category successfully deleted";
            }

            return RedirectToPage("Index");
        }
    }
}
