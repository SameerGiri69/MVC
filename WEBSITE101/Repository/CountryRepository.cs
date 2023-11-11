using WEBSITE101.Data;
using WEBSITE101.DTO;
using WEBSITE101.Interface;
using WEBSITE101.Model;

namespace WEBSITE101.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool AddCountry(CountryDto countrydto)
        {
            Country country = new Country();
            country.Name = countrydto.Name;
            country.Id = countrydto.Id;
            var rowsAffected = _context.Countries.Add(country);
            if (rowsAffected == null)
                return false;
            return true;
        }

        public bool CountryExists(int countryId)
        {
            var country = _context.Countries.Where(x => x.Id == countryId).FirstOrDefault();
            if(country == null)
                return false;
            return true;
        }

        public bool DeleteCountry(int countryId)
        {
            var country =_context.Countries.Where(x => x.Id == countryId).FirstOrDefault();
            if (country == null)
                return false;
               _context.Remove(country);
            var result = _context.SaveChanges();
            if (result < 0)
                return false;
            return true;
            
        }

        public CountryDto GetCountryById(int countryId)
        {
            var country = _context.Countries.Where(x => x.Id == countryId).FirstOrDefault();
            CountryDto countryDto = new CountryDto();
            countryDto.Id = country.Id;
            countryDto.Name = country.Name;
            return (countryDto);
        }

        public CountryDto GetCountryByName(string name)
        {
            var country = _context.Countries.Where(x => x.Name == name).FirstOrDefault();
            CountryDto countryDto = new CountryDto();
            countryDto.Id = country.Id;
            countryDto.Name = country.Name;
            return (countryDto);
        }

        public bool UpdateCountry(string countryName, int countryId)
        {
            var country = _context.Countries.Where(x => x.Id == countryId).FirstOrDefault();
            country.Name = countryName;
            country.Id = countryId;
            var result = _context.SaveChanges();
            if(result < 0)
                return false;
            return true;

        }
    }
}
