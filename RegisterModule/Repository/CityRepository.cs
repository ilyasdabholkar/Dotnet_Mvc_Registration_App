using Microsoft.EntityFrameworkCore;
using RegisterModule.Context;
using RegisterModule.Interfaces;
using RegisterModule.Models;
using System.Data;

namespace RegisterModule.Repository
{
    public class CityRepository : ICityRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CityRepository(ApplicationDbContext ctx)
        {
            this._dbContext = ctx;
        }

        public List<City> GetCities(int stateId)
        {
            List<City> cities = _dbContext.City.Where(c => c.StateId == stateId).Include(c=>c.State).ToList();
            return cities;
        }
    }
}
