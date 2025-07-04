using CINEMA.Models;

namespace CINEMA.Model_view
{
    public class ModelAndActorMovieVM
    {
        public Movie Movie { get; set; }
        public List<ActorMovie> ActorMovies { get; set; }
    }
}
