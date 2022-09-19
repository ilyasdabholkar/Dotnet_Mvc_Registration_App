using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterModule.Interfaces;

namespace RegisterModule.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            this._countryService = countryService;
        }

        [HttpPost]
        public JsonResult GetCountries()
        {

            var countries = _countryService.GetAllCountries();
            List<SelectListItem> countryList = (from country in countries
                                                select new SelectListItem
                                                {
                                                    Value = country.CountryId.ToString(),
                                                    Text = country.CountryName.ToString()
                                                }).ToList();
            return Json(countryList);
        }
    }
}
