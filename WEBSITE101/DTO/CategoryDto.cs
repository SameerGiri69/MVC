using WEBSITE101.Model;

namespace WEBSITE101.DTO
{
    public class CategoryDto
    {
        
            public int Id { get; set; }
            public string? Name { get; set; }
            public List<PokemonCategory>? PokemonCategories { get; set; }

        
    }
}
