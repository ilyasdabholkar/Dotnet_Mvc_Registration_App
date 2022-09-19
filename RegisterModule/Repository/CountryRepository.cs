using RegisterModule.Context;
using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext ctx)
        {
            this._dbContext = ctx;
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = _dbContext.Country.ToList();
            return countries;
        }

    }

}
