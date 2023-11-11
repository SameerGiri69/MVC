using WEBSITE101.Model;

namespace WEBSITE101.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Rating { get; set; }
        public string? Text { get; set; }
        public Reviewer? Reviewer { get; set; }
        public Pokemons? Pokemon { get; set; }
    }
}
