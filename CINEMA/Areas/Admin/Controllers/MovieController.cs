using CINEMA.Data;
using CINEMA.Model_view;
using CINEMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CINEMA.Areas.Admin.Controllers
{ [Area("Admin")]
    public class MovieController : Controller
    {
        private ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var Movies = _context.Movies.Include(e => e.Category);
            return View(Movies.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var Categories = _context.Categories;
            var Cinemas = _context.Cinemas;

            CategoryWithCinemaVM categoryWithCinemaVM = new()
            {
                Categories = Categories.ToList(),
                Cinemas =Cinemas.ToList()
            };           
            return View(categoryWithCinemaVM);

        }

        [HttpPost]
        public IActionResult Create(Movie Movie)
        { 
            _context.Add(Movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edite([FromRoute]int Id)
        { 
        var Movie = _context.Movies.Find(Id);
            var Categories = _context.Categories;
            var Cinemas = _context.Cinemas;

            CategoryWithCinemaVM categoryWithCinemaVM = new()
            {
                Categories = Categories.ToList(),
                Cinemas = Cinemas.ToList(),
                Movie = Movie
            };
            return View(categoryWithCinemaVM);
        }

        [HttpPost]
        public IActionResult Edite(Movie Movie)
        {
            _context.Update(Movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var Movie = _context.Movies.Include(e => e.Cinema).Include(e => e.Category).FirstOrDefault(e => e.Id == id);
           
               
                return View(Movie);
            
        }
        public IActionResult Delete([FromRoute] int Id)
        {
            var Movie = _context.Movies.Find(Id); 
            _context.Remove(Movie);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
