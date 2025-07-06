using CINEMA.Data;
using CINEMA.Models;
using Microsoft.AspNetCore.Mvc;

namespace CINEMA.Areas.Admin.Controllers
{ [Area("Admin")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var Categories = _context.Categories;
            return View(Categories.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        { 
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edite([FromRoute]int id)
        { 
        var Category = _context.Categories.Find(id);
            return View(Category);
        }

        [HttpPost]
        public IActionResult Edite(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }

}
