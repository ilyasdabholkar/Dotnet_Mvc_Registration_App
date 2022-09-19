using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface ICountryService
    {
        public List<Country> GetAllCountries();
    }
}
