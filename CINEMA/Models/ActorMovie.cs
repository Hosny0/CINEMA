namespace CINEMA.Models
{
    public class ActorMovie
    {
        public int Id { get; set; }
        public int ActorsId { get; set; }
        public int MoviesId { get; set; }
        public Movie Movie { get; set; } = null!;
        public Actor Actor { get; set; } = null!;

    }
}
