using CINEMA.Models;

namespace CINEMA.Model_view
{
    public class CategoryWithCinemaVM
    {
        public List<Category> Categories { get; set; }
        public List<Cinema> Cinemas{ get; set; }
        public Movie? Movie { get; set; }
    }
}
