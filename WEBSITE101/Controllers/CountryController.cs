using Microsoft.AspNetCore.Mvc;
using WEBSITE101.DTO;
using WEBSITE101.Interface;

namespace WEBSITE101.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryColtroller : Controller
    {

        private readonly ICountryRepository _countryRepository;
        public CountryColtroller(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public IActionResult AddCountry(CountryDto country)
        {
            var result = _countryRepository.AddCountry(country);
            if (result == false)
                return BadRequest();
            return Ok();
        }
        public IActionResult GetCountryById(int countryId)
        {
            var country = _countryRepository.GetCountryById(countryId);
            //CountryDto dtoCountry = new CountryDto();
            //dtoCountry.Id = country.Id;
            //dtoCountry.Name = country.Name;
            if (country == null)
                return NotFound();
            return Ok(country);

        }
        public IActionResult GetCountryByName(string name)
        {
            var country = _countryRepository.GetCountryByName(name);
            if(country == null)
                return NotFound(name);
            return Ok(country);
        }
        public IActionResult UpdateCountry(string country)
        {
            var result = _countryRepository.UpdateCountry(country);
            if (result == false)
                return BadRequest();
            return Ok ();
            
        }
        public IActionResult DeleteCountry(int countryId)
        {
            var result = _countryRepository.DeleteCountry(countryId);
            if (result == false)
                return NotFound();
            return Ok();
        }
        public IActionResult CountryExists(int countryId)
        {
            var result = _countryRepository.CountryExists(countryId);
            if (result == false)
                return NotFound();
            return Ok();
        }
    }
}
