using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = _countryRepository.GetAllCountries();
            return countries;
        }
    }
}
