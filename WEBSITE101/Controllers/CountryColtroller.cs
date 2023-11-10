using WEBSITE101.Interface;

namespace WEBSITE101.Controllers
{
    public class CountryColtroller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryColtroller(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

    }
}
