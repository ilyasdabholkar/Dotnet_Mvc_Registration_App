using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterModule.Interfaces;
using RegisterModule.Models;
using RegisterModule.Service;

namespace RegisterModule.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            this._cityService = cityService;
        }

        [HttpPost]
        public JsonResult GetCity(int id)
        {

            List<City> cities = _cityService.GetCities(id);
            List<SelectListItem> cityList = (from city in cities
                                              select new SelectListItem
                                              {
                                                  Value = city.CityId.ToString(),
                                                  Text = city.CityName.ToString()
                                              }).ToList();
            return Json(cityList);
        }
    }
}
