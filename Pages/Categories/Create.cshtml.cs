using ASP.NET_with_razor_pages.Data;
using ASP.NET_with_razor_pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_with_razor_pages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty] //Or use global [BindProperties] if more than one property used in UI
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            //to add custom validation
            if(Category.Name == Category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Display Order Cannot Exactly Match The Name");
                // to display an error under a specific property pass the property name as first arg, otherwise pass a string.empty to display it only in summarized errors
            }
            //server side default validation
            if (ModelState.IsValid) //Check if name and display order are valid
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category successfully created";
                return RedirectToPage("Index");
            }
            return Page(); //if not valid go back to same page
        }
    }
}
