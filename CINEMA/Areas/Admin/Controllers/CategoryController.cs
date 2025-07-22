using CINEMA.Data;
using CINEMA.Models;
using CINEMA.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace CINEMA.Areas.Admin.Controllers
{ [Area("Admin")]
    public class CategoryController : Controller
    {

        //private ApplicationDbContext _context = new();
        // private Repository<Category> _categoryRepository = new();
        private ICategoryRepository _CategoryRepository;
    

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        public async Task<IActionResult> Index()
        {
            var Categories = await _CategoryRepository.GetAsync();

            return View(Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
           await _CategoryRepository.CreateAsync(category);
          await  _CategoryRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]int id)
        { 
        var Category =await _CategoryRepository.GetOneAsync(e=>e.Id == id);
            return View(Category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            _CategoryRepository.Edit(category);
            await _CategoryRepository.CommitAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var Category = await _CategoryRepository.GetOneAsync(e =>e.Id == id);
            _CategoryRepository.Delete(Category);
            await _CategoryRepository.CommitAsync();

            return RedirectToAction(nameof(Index));
        }
    }

}
