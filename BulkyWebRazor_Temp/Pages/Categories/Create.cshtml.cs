using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly AppDbContext appDbContext;

        public CreateModel(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Category Category { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            appDbContext.Categories.Add(Category);
            appDbContext.SaveChanges();
            TempData["success"] = "Category created successfully";
            return RedirectToPage("Index");
        }
    }
}
