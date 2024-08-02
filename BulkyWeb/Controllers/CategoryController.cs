using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext appDbContext;

        public CategoryController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Category> categories = appDbContext.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.Name != null && category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                appDbContext.Categories.Add(category);
                appDbContext.SaveChanges();
                TempData["success"] = "Category created successfully"; 
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int? categoryId)
        {
            if (categoryId == null || categoryId == 0)
            {
                return NotFound();
            }
            Category? category = appDbContext.Categories.Find(categoryId);
            //Category? category1 = appDbContext.Categories.FirstOrDefault(c=>c.Id == categoryId);
            //Category? category2 = appDbContext.Categories.Where(c=>c.Id == categoryId).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the name.");
            }
            if (ModelState.IsValid)
            {
                appDbContext.Categories.Update(category);
                appDbContext.SaveChanges();
                TempData["success"] = "Category updated successfully";

                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = appDbContext.Categories.Find(id);
            //Category? category1 = appDbContext.Categories.FirstOrDefault(c=>c.Id == categoryId);
            //Category? category2 = appDbContext.Categories.Where(c=>c.Id == categoryId).FirstOrDefault();

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(Category category)
        {

            appDbContext.Categories.Remove(category);
            appDbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

