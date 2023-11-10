using WEBSITE101.Model;

namespace WEBSITE101.DTO
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Owner>? Owners { get; set; }
    }
}
