using WEBSITE101.DTO;
using WEBSITE101.Model;

namespace WEBSITE101.Interface
{
    public interface IPokemonRepository
    {
        //we inherit this interface in PokemonRepository.cs to implement these 
        //methods (this is done for purpose of abstraction and security)
        List<PokemonDto> GetPokemons();

        bool AddPokemon(PokemonDto pokemon);
        bool DeletePokemon(int pokeId);
        PokemonDto GetPokemon(int id);
        Pokemons GetPokemon(string name);
        bool PokemonExists(int pokeId);
        bool UpdatePokemon(PokemonDto pokemon);
        decimal GetPokemonRating(int pokeId);

    }
}
