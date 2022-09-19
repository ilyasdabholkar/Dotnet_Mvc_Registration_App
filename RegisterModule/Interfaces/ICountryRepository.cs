using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface ICountryRepository
    {
        public List<Country> GetAllCountries();
    }
}
