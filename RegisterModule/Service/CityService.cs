using RegisterModule.Interfaces;
using RegisterModule.Models;
using RegisterModule.Repository;

namespace RegisterModule.Service
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public List<City> GetCities(int stateId)
        {
            List<City> cities = _cityRepository.GetCities(stateId);
            return cities;
        }
    }
}
