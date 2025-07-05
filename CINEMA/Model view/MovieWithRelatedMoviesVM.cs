using CINEMA.Models;

namespace CINEMA.Model_view
{
    public class MovieWithRelatedMoviesVM
    {
        public Movie Movie { get; set; } = null!;
        public List<Movie> RelatedMovies { get; set; } = null!;
    }
}
