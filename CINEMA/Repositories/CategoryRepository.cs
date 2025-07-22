using CINEMA.Data;
using CINEMA.Models;
using CINEMA.Repositories.IRepositories;

namespace CINEMA.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
