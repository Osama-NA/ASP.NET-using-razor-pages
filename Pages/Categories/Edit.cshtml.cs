using ASP.NET_with_razor_pages.Data;
using ASP.NET_with_razor_pages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_with_razor_pages.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty] //Or use global [BindProperties] if more than one property used in UI
        public Category Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id); // id is passed by asp-route-id in Index.cshtml

            /*
                 // returns first result found or null if none found
                Category = _db.Category.FirstOrDefault(u => u.Id == id);

                 // returns one result and if more than one is found it returns exception
                Category = _db.Category.SingleOrDefault(u => u.Id == id);

                 // returns all results that match given id then returns first result found or null if none found
                Category = _db.Category.Where(u=>u.Id == id).FirstOrDefault();
            */
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
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category successfully updated";
                return RedirectToPage("Index");
            }
            return Page(); //if not valid go back to same page
        }
    }
}
