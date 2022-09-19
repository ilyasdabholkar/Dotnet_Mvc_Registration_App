using RegisterModule.Models;

namespace RegisterModule.Interfaces
{
    public interface ICityService
    {
        public List<City> GetCities(int stateId);
    }
}
