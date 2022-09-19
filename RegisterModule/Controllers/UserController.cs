using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterModule.Enums;
using RegisterModule.Interfaces;
using RegisterModule.Models;

namespace RegisterModule.Controllers
{
    public class UserController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(ICountryService countryService, IUserService userService, IConfiguration configuration)
        {
            _countryService = countryService;
            _userService = userService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var genderData = from GenderEnum e in Enum.GetValues(typeof(GenderEnum))
                           select new
                           {
                               ID = (int)e,
                               Name = e.ToString()
                           };
            List<Country> countries = _countryService.GetAllCountries();

            ViewBag.GenderList = new SelectList(genderData, "ID", "Name");
            ViewBag.CountryList = new SelectList(countries, "CountryId", "CountryName");

            return View();
        }

        [HttpPost]
        public IActionResult Register(User u,string Relocate,IFormFile resume)
        {
            u.ReadyToRelocate = Convert.ToBoolean(Relocate);
            if (resume != null)
            {
                var ext = Path.GetExtension(resume.FileName);
                string name = Path.GetFileNameWithoutExtension(resume.FileName);
                string myFile = name + "_" + Guid.NewGuid().ToString() + ext;
                var filePath = Path.Combine(_configuration.GetValue<string>("AppConfig:ResumeUploadPath"), myFile);
                using var fileStream = new FileStream(filePath, FileMode.Create);
                resume.CopyTo(fileStream);
                u.ResumePath = u.ResumeTitle+'-'+myFile;
            }

            if (ModelState.IsValid)
            {
                _userService.AddUser(u);
                TempData["type"] = "success";
                TempData["msg"] = "User Added Successfully";
                return RedirectToAction("Register");
            }
            else
            {
                TempData["type"] = "danger";
                TempData["msg"] = "Failed to add user";
            }

            return RedirectToAction("Register");
        }

        //Remote validation
        [HttpPost]
        public JsonResult DoesUserEmailExist(string Email)
        {
            var user = _userService.FindByEmail(Email);
            return Json(user == null);
        }
    }
}
