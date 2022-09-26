using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RegisterModule.Models
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? UserId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [StringLength(60, MinimumLength = 6)]
        [Remote("DoesUserEmailExist", "User", HttpMethod = "POST", ErrorMessage = "User with this email already exists")]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Email Address")]
        public string? Email { get; set; }

        [Display(Name = "Alternate Email Id")]
        [DataType(DataType.EmailAddress)]
        [StringLength(60, MinimumLength = 6)]
        //[Remote("DoesUserAlternateEmailExist", "User", HttpMethod = "POST", ErrorMessage = "User With This Alternate Address Already Exists")]
        [Remote("IsEmailSame", "User", HttpMethod = "POST", AdditionalFields = "Email", ErrorMessage = "Alternate Email Address And Email Address Cannot Be Same")]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Alternate Email Address")]
        public string? AlternateEmail { get; set; } = string.Empty;



        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid Last Name")]
        public string? LastName { get; set; }

        [NotMapped]
        [Required]
        [DataType("Password")]
        [Display(Name = "Choose a Password")]
        [StringLength(80, MinimumLength = 8)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,80}$", ErrorMessage = "Password Must contain Atleast One Uppercase Letter,Lowercase Letter, Digit And A Special Character")]
        public string? Password { get; set; }

        [NotMapped]
        [Required]
        [DataType("Password")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,80}$", ErrorMessage = "Password Must contain Atleast One Uppercase Letter,Lowercase Letter, Digit And A Special Character")]
        [Display(Name = "Re-enter Password")]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }

        public Byte[]? PasswordHash { get; set; }

        [Required]
        public Byte[]? PasswordSalt { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "Looking For")]
        [StringLength(80)]
        public string? JobType { get; set; }

        [Required]
        [Display(Name = "Your Status")]
        [StringLength(40)]
        public string? EmploymentStatus { get; set; }


        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Mobile")]
        [Remote("DoesUserMobileNoExists", "User", HttpMethod = "POST", ErrorMessage = "User With This Mobile Number Already Exists")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Please Enter A Valid Mobile Number")]
        public string? MobileNo { get; set; } = string.Empty;


        [Required]
        [Display(Name = "Date Of Birth")]
        [Remote("IsDateValid", "User", HttpMethod = "POST", ErrorMessage = "Age must be greater than 18")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string? Gender { get; set; }


        [Required]
        [StringLength(10)]
        public string? MaritialStatus { get; set; }

        [Required]
        [Display(Name = "Country")]
        public int? CountryId { get; set; }

        [Required]
        [Display(Name = "State")]
        public int? StateId { get; set; }

        [Display(Name = "District")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid District Name")]
        public string? District { get; set; } = string.Empty;

        [Required]
        [Display(Name = "City")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Locality")]
        public string? Locality { get; set; }

        [Required]
        [Display(Name = "ZipCode")]
        [StringLength(6)]
        [RegularExpression("^[0-9]{6}$", ErrorMessage = "Please Enter A Valid Zip Code")]
        public string? ZipCode { get; set; }

        [Required]
        [Display(Name = "Highest Qualification Held")]
        public string? HighestQualification { get; set; }

        [Required]
        [Display(Name = "Specialization")]
        public string? Specialization { get; set; }

        [Required]
        [Display(Name = "Institue")]
        public string? Institute { get; set; }

        [Display(Name = "Please specify(if any other institute)")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Institute Name")]
        public string? OtherInstitute { get; set; } = string.Empty;

        [Display(Name = "Preferred Location")]
        [StringLength(30)]
        public string? PrefferedLocation { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Are you ready to relocate?")]
        public bool? ReadyToRelocate { get; set; } = false;

        [Required]
        [Display(Name = "Total Experience (Months)")]
        public int? TotalExperience { get; set; }

        [NotMapped]
        public int? ExperienceYears { get; set; }

        [NotMapped]
        public int? ExperienceMonths { get; set; }

        [Required]
        [Display(Name = "Job Category")]
        [StringLength(40)]
        public string? JobCategory { get; set; }

        [Display(Name = "Key Skills")]
        [StringLength(40, MinimumLength = 2)]
        public string? KeySkills { get; set; }

        [Display(Name = "Current Industry")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Industry")]
        public string? CurrentIndustry { get; set; } = string.Empty;

        [Display(Name = "Current Employer")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Employer")]
        public string? CurrentEmployer { get; set; } = string.Empty;

        [Display(Name = "Current Designation")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Designation")]
        public string? CurrentDesignation { get; set; } = string.Empty;

        [Display(Name = "Previous Employer")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Employer")]
        public string? PreviousEmployer { get; set; } = string.Empty;

        [Display(Name = "Previous Designation")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Designation")]
        public string? PreviousDesignation { get; set; } = string.Empty;

        [Display(Name = "Notice Period")]
        [StringLength(15)]
        public string? NoticePeriod { get; set; } = "Immediately";

        [Display(Name = "CTC (per anum)")]
        public int? Ctc { get; set; } = 0;

        [NotMapped]
        public int? CtcLakhs { get; set; } = 0;

        [NotMapped]
        public int? CtcThousands { get; set; } = 0;

        [Required]
        [Display(Name = "Resume Title")]
        [StringLength(25)]
        [RegularExpression(@"^([A-Za-z ]|[0-9]|_)+$", ErrorMessage = "Please Enter A Valid Resume Title")]
        public string? ResumeTitle { get; set; }

        public string? ResumePath { get; set; } = string.Empty;

        [System.Web.Mvc.AllowHtml]
        public string? Resume { get; set; } = string.Empty;

        public bool? IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime DeletedOn { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        [ForeignKey("StateId")]
        public virtual State? State { get; set; }

        [ForeignKey("CityId")]
        public virtual City? City { get; set; }

        public virtual ICollection<UserJobType>? UserJobTypes { get; set; }

    }
}
