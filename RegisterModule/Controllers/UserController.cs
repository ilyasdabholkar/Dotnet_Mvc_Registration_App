using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RegisterModule.Enums;
using RegisterModule.Interfaces;
using RegisterModule.Models;
using System.Web.WebPages;

namespace RegisterModule.Controllers
{
    public class UserController : Controller
    {
        private readonly ICountryService _countryService;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IPasswordService _passwordService;
        private readonly IEmailService _emailService;
        private readonly IJobTypeService _jobTypeService;
        private readonly IUserJobTypeService _userJobTypeService;


        public UserController(ICountryService countryService, IUserService userService,
                               IConfiguration configuration, IPasswordService passwordService,
                               IEmailService emailService, IJobTypeService jobTypeService,
                            IUserJobTypeService userJobTypeService)
        {
            _countryService = countryService;
            _userService = userService;
            _configuration = configuration;
            _passwordService = passwordService;
            _emailService = emailService;
            _jobTypeService = jobTypeService;
            _userJobTypeService = userJobTypeService;
        }

        public IActionResult DisplayUserData()
        {
            List<User> users = _userService.GetAllUsers();
            return View(users);
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
            List<JobType> jobTypes = _jobTypeService.GetJobTypes();

            ViewBag.GenderList = new SelectList(genderData, "ID", "Name");
            ViewBag.CountryList = new SelectList(countries, "CountryId", "CountryName");
            ViewBag.JobTypes = new SelectList(jobTypes, "JobId", "Type");


            int[] yearValues = Enumerable.Range(1, 20).ToArray();
            var yearData = yearValues.Select((i) => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            ViewBag.YearList = yearData;

            int[] monthValues = Enumerable.Range(1, 11).ToArray();
            var monthData = monthValues.Select((i) => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            ViewBag.MonthList = monthData;

            int[] lakhsValues = Enumerable.Range(1, 99).ToArray();
            var lakhData = lakhsValues.Select((i) => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            ViewBag.LakhList = lakhData;

            int[] thousandsValues = Enumerable.Range(1, 99).ToArray();
            var thousandData = thousandsValues.Select((i) => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
            ViewBag.ThousandList = thousandData;

            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string Relocate, IFormFile? resume, string? TxtResume, int[]? JobTypes)
        {
            ModelState.Remove("TotalExperience");
            ModelState.Remove("PasswordSalt");
            ModelState.Remove("JobType");
            ModelState.Remove("UserJobTypes");
            if (ModelState.IsValid)
            {

                user.ReadyToRelocate = Convert.ToBoolean(Relocate);
                if (resume != null)
                {
                    var ext = Path.GetExtension(resume.FileName);
                    string name = Path.GetFileNameWithoutExtension(resume.FileName);
                    string myFile = name + "_" + Guid.NewGuid().ToString() + ext;
                    var filePath = Path.Combine(_configuration.GetValue<string>("AppConfig:ResumeUploadPath"), myFile);
                    using var fileStream = new FileStream(filePath, FileMode.Create);
                    resume.CopyTo(fileStream);
                    user.ResumePath = myFile;
                }

                user.TotalExperience = (user.ExperienceYears * 12) + (user.ExperienceMonths);
                user.Ctc = (user.CtcLakhs * 100) * 1000 + (user.CtcThousands * 1000);

                _passwordService.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Resume = TxtResume;
                bool userAdded = _userService.AddUser(user);

                if (userAdded)
                {
                    User insertedUser = _userService.FindByEmail(user.Email);
                    _userJobTypeService.AddUserJobTypes(JobTypes, (int)insertedUser.UserId);

                    string username = user.FirstName + " " + user.LastName;
                    _emailService.Send(user.Email, username);
                    TempData["type"] = "success";
                    TempData["msg"] = "User Registered Successfully";
                }
                else
                {
                    TempData["type"] = "danger";
                    TempData["msg"] = "Failed To Register User";
                }

                return RedirectToAction("Register");
            }
            else
            {
                TempData["type"] = "danger";
                TempData["msg"] = "Failed to add user";
            }

            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult DownloadResume(string fileName)
        {
            var path = Path.Combine(_configuration.GetValue<string>("AppConfig:ResumeUploadPath"), fileName);
            var fs = new FileStream(path, FileMode.Open);
            return File(fs, "application/octet-stream", fileName);

        }
        
        public IActionResult PrintDetails(int id)
        {
            User user = _userService.GetAllUsers().FirstOrDefault(item => item.UserId == id);
            Console.WriteLine($"#########################{user.FirstName}");
            return RedirectToAction("DisplayUserData");
        }

        //Remote validation
        [HttpPost]
        public JsonResult DoesUserEmailExist(string Email)
        {
            var user = _userService.FindByEmail(Email);
            return Json(user == null);
        }

        [HttpPost]
        public JsonResult DoesUserAlternateEmailExist(string AlternateEmail)
        {
            var user = _userService.FindByAlternateEmail(AlternateEmail);
            return Json(user == null);
        }

        [HttpPost]
        public JsonResult IsDateValid(DateTime DateOfBirth)
        {
            DateTime CurrentDate = DateTime.Today;
            int age = CurrentDate.Year - DateOfBirth.Year;
            if (age < 18)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }


        [HttpPost]
        public JsonResult DoesUserMobileNoExists(string MobileNo)
        {
            var user = _userService.FindByMobile(MobileNo);
            return Json(user == null);
        }

        [HttpPost]
        public JsonResult IsEmailSame(string Email, string AlternateEmail)
        {
            if (AlternateEmail != "" && AlternateEmail.Equals(Email))
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

    }
}
