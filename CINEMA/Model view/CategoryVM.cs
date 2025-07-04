using CINEMA.Models;

namespace CINEMA.Model_view
{
    public class CategoryVM
    {
        public List<Category> Categories { get; set; } = null!;
        public List<Cinema > Cinemas { get; set; } = null!;
        public List<Actor> Actors { get; set; } = null!;
        public Movie? Movie { get; set; }

    }
}
