using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface ICityRepository
    {
        public List<City> GetCities(int stateId);
    }
}
