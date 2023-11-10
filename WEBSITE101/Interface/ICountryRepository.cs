namespace WEBSITE101.Interface
{
    public interface ICountryRepository
    {
        bool GetCountry(int countryId);
        bool AddCountry(string countryName);
        bool DeleteCountry(string countryName);


    }
}
