using CINEMA.Data;
using CINEMA.Model_view;
using CINEMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CINEMA.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MovieController : Controller
    {
        private ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var Movie = _context.Movies.Include(e => e.Category);
            return View(Movie.ToList());
        }
     //   [HttpGet]
     //   public IActionResult Create()
     //   {
     //       var categories = _context.Categories;
     //       var Cinemas = _context.Cinemas;
     //       var Actors = _context.Actors;
     //       CategoryVM categoryVM = new()
     //       {
     //           Categories =  categories,
     //           Cinemas = Cinemas,
     //           Actors = Actors
     //       };
     //       return View(categoryVM);
     //   }
     //
    }
}
