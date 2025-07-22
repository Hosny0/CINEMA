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
        public IActionResult Create(Movie Movie , IFormFile ImgUrl)
        {
            if (ImgUrl is not null && ImgUrl.Length > 0)
            {
                var FileName = Guid.NewGuid().ToString() + Path.GetExtension(ImgUrl.FileName);
                var FilePath=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", FileName);
                using (var stream = System.IO.File.Create(FilePath))
                {
                    ImgUrl.CopyTo(stream); 
                }
                Movie.ImgUrl=FileName;
                 _context.Add(Movie);
                TempData["success_notification"] = "Add Movie Successfully";
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult Edit([FromRoute]int Id)
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
        public IActionResult Edit(Movie Movie, IFormFile? imgUrl)
        {
            var MovieInDB = _context.Movies.AsNoTracking().FirstOrDefault(e => e.Id == Movie.Id);
           
            
            
            if (MovieInDB is not null)
            {


                if (imgUrl is not null && imgUrl.Length > 0)
                {
                    var FileName = Guid.NewGuid().ToString() + Path.GetExtension(imgUrl.FileName);
                    var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", MovieInDB.ImgUrl);
                    //save img in wwwroot
                    using (var stream = System.IO.File.Create(FilePath))
                    {
                        imgUrl.CopyTo(stream);
                    }


                    //Delete old img from wwroot
                    var OldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", MovieInDB.ImgUrl);
                   
                    if (System.IO.File.Exists(OldFilePath))
                    {
                        System.IO.File.Delete(OldFilePath);

                    }


                    //save img in Db
                    Movie.ImgUrl = FileName;
                }
                else
                {
                    Movie.ImgUrl = MovieInDB.ImgUrl;

                }
                      //update img in db
                    _context.Update(Movie);
                TempData["success_notification"] = "Update Movie Successfully";

                _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                
            }       
            
            return NotFound();

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

            //عشان لو مسحنا الصوره تتمسح من الwwroot
            var OldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", Movie.ImgUrl);

            if (System.IO.File.Exists(OldFilePath))
            {
                System.IO.File.Delete(OldFilePath);

            }

            _context.Remove(Movie);
            TempData["success_notification"] = "Delete Movie Successfully";

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }

}
