namespace WEBSITE101.Model
{
    public class PokemonOwner
    {
        public int PokemonId { get; set; }
        public int OwenrId { get; set; }
        public Pokemons? Pokemons { get; set; }
        public Owner? Owner { get; set; }
    }
}
