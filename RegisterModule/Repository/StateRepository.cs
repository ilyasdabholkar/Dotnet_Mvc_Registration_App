using Microsoft.EntityFrameworkCore;
using RegisterModule.Context;
using RegisterModule.Interfaces;
using RegisterModule.Models;
using System.Data;

namespace RegisterModule.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StateRepository(ApplicationDbContext ctx)
        {
            this._dbContext = ctx;
        }
        public List<State> GetStates(int countryId)
        {
            List<State> states = _dbContext.State.Where(s => s.CountryId == countryId).Include(s=>s.Country).ToList();
            return states;
        }
    }
}
