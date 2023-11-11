using Microsoft.AspNetCore.Mvc;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult AddCountry(CountryDto country)
        {
            var result = _countryRepository.AddCountry(country);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(404)]
        public IActionResult GetCountryById(int countryId)
        {
            var country = _countryRepository.GetCountryById(countryId);
            if (country == null)
                return NotFound();
            return Ok(country);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(404)]
        public IActionResult GetCountryByName(string name)
        {
            var country = _countryRepository.GetCountryByName(name);
            if (country == null)
                return NotFound(name);
            return Ok(country);
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult UpdateCountry(int countryId, string country)
        {
            bool result = _countryRepository.UpdateCountry(country, countryId);
            if (!result)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCountry(int countryId)
        {
            var result = _countryRepository.DeleteCountry(countryId);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpGet("exists/{countryId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult CountryExists(int countryId)
        {
            var result = _countryRepository.CountryExists(countryId);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
}
