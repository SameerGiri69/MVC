using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WEBSITE101.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public Reviewer Reviewer { get; set; }
        public Pokemons Pokemon { get; set; }
    }
}
