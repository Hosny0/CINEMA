using CINEMA.Data;
using CINEMA.Model_view;
using CINEMA.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CINEMA.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private readonly ApplicationDbContext _context = new();

        public IActionResult Index()
        {
            var Movies = _context.Movies.Include(e => e.Cinema).Include(e => e.Category).ToList()
;
            if (Movies == null)
            {
                return NotFound();
            }
            return View(Movies);

        }
        public IActionResult Details( int id)
        {
            var Movie = _context.Movies.Include(e => e.Cinema).Include(e => e.Category).FirstOrDefault(e => e.Id == id);
            if (Movie is not null)
            {   
             var RelatedMovies=   _context.Movies.Where(e => e.CategoryId == Movie.CategoryId && e.Id != Movie.Id).Skip(0).Take(4);
                var MovieWithRelatedMovies = new MovieWithRelatedMoviesVM()
                { 
                    Movie = Movie,
                    RelatedMovies = RelatedMovies.ToList()
                };
                return View(MovieWithRelatedMovies);
            }
          

            return NotFound();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotFoundPage()
        {
            return View();
        }
    }
}
