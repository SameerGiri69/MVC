using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemons>))]
        public IActionResult Index()
        {
            var poke = _pokemonRepository.GetPokemons();

            if (poke.Count < 1)
            {

                ModelState.AddModelError("", "No Pokemons found");
                return BadRequest(ModelState);
            }
            return Ok(poke);
        }
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type = typeof(Pokemons))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemon(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();
            var pokemon = _pokemonRepository.GetPokemon(pokeId);

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(pokemon);
        }

        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(Pokemons))]
        [ProducesResponseType(400)]

        public IActionResult GetPokemonRating(int pokeId)
        {
            if (!_pokemonRepository.PokemonExists(pokeId))
                return NotFound();
            var rating = _pokemonRepository.GetPokemonRating(pokeId);

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }
        [HttpPost]
        public IActionResult AddPokemon(PokemonDto pokemonDto)
        {
            var result = _pokemonRepository.AddPokemon(pokemonDto);
            if (result == false)
                return BadRequest();
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeletePokemon(int pokeId)
        {
            var result = _pokemonRepository.DeletePokemon(pokeId);
            if (result == false) return BadRequest();   
            return Ok();
        }
    }
}
