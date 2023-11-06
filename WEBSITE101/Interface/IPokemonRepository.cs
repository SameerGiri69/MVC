using WEBSITE101.Model;

namespace WEBSITE101.Interface
{
    public interface IPokemonRepository
    {
        //we inherit this interface in PokemonRepository.cs to implement these 
        //methods (this is done for purpose of abstraction and security)
        List<Pokemons> GetPokemons();

        bool AddPokemon(Pokemons pokemon);
        bool DeletePokemon(Pokemons pokemon);
        Pokemons GetPokemon(int id);
        Pokemons GetPokemon(string name);
    }
}
