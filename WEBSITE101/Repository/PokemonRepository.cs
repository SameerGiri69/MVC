using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WEBSITE101.Data;
using WEBSITE101.DTO;
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

        public bool AddPokemon(PokemonDto pokemon)
        {
            Pokemons pokemons = new Pokemons()
            {
           
                Name = pokemon.Name,
                BirthDate = pokemon.BirthDate,
                    
            };
            _context.Pokemons.Add(pokemons);
            var rowsAffected = _context.SaveChanges();
            if (rowsAffected < 1)
            {
                return false;
            }
                return true;
        }

        public bool DeletePokemon(int pokeId)
        {
            var pokemon = _context.Pokemons.Where(x => x.Id == pokeId).FirstOrDefault();
            _context.Pokemons.Remove(pokemon);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected <= 0)
                return false;
            return true;
        }
        public bool UpdatePokemon(PokemonDto pokemon)
        {
         
         
            var poke = _context.Pokemons.Where(x => x.Id == pokemon.Id).FirstOrDefault();
            poke.Name = pokemon.Name;
            poke.BirthDate = pokemon.BirthDate;
            _context.Pokemons.Update(poke);
            var rowsAffected = _context.SaveChanges();

            return rowsAffected < 1 ? false : true; 


        }

        public PokemonDto GetPokemon(int id)

        {
           var pokemon =  _context.Pokemons.Where(x=>x.Id==id).FirstOrDefault();
            PokemonDto poke = new PokemonDto();
            poke.Id = pokemon.Id;
            poke.Name = pokemon.Name;
            poke.BirthDate = pokemon.BirthDate;
            return poke;
        }

        public Pokemons GetPokemon(string name)
        {
            return _context.Pokemons.Where(x => x.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Pokemon.Id == pokeId);

            if (review == null)
                return 0; 

            return Convert.ToDecimal(review.Rating);
        }
    


        public List<PokemonDto> GetPokemons()
        {
            List<Pokemons>? result = _context.Pokemons
                .Include(x => x.Reviews)
                .Include(y => y.PokemonCategories)
                .ToList();
            List < PokemonDto > dtos = new List<PokemonDto>();
            foreach(var item in result)
            {
                PokemonDto obj = new PokemonDto()
                {
                    Name = item.Name,
                    BirthDate = item.BirthDate,
                };
                dtos.Add(obj);
            }
            return dtos;

        }
        public bool PokemonExists(int pokeId)
        {
           return _context.Pokemons.Any(x => x.Id == pokeId);
        }

        
    }
}
