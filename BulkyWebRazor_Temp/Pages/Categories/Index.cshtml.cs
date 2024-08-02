using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext appDbContext;
        public List<Category> Categories { get; set; }
        public IndexModel(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void OnGet()
        {
            Categories = appDbContext.Categories.ToList();
        }
    }
}
