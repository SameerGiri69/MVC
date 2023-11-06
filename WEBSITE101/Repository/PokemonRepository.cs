using Microsoft.EntityFrameworkCore;
using WEBSITE101.Data;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool AddPokemon(Pokemons pokemon)
        {
            _context.Pokemons.Add(pokemon);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 1)
            {
                return false;
            }
                return true;
        }

        public bool DeletePokemon(Pokemons pokemon)
        {
            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();
            return true;
        }

        public Pokemons GetPokemon(int id)

        {
           return _context.Pokemons.Where(x=>x.Id==id).FirstOrDefault();
        }

        public Pokemons GetPokemon(string name)
        {
            return _context.Pokemons.Where(x => x.Name == name).FirstOrDefault();
        }

        public List<Pokemons> GetPokemons()
        {
            return _context.Pokemons.Include(x=>x.PokemonCategories ).Include(x=> x.Reviews).ToList();

        }
    }
}
