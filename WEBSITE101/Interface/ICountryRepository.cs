using WEBSITE101.DTO;

namespace WEBSITE101.Interface
{
    public interface ICountryRepository
    {
        CountryDto GetCountryById(int countryId);
        CountryDto GetCountryByName(string name);
        bool AddCountry(CountryDto countryDto);
        bool DeleteCountry(int countryId);
        bool UpdateCountry(string countryName, int countryId);
        bool CountryExists(int countryId);


    }
}
