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

        [Required]
        [Display(Name = "Looking For")]
        [StringLength(80)]
        public string? JobType { get; set; }

        [Required]
        [Display(Name = "Your Status")]
        [StringLength(40)]
        public string? EmploymentStatus { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNo { get; set; } = "";

        [Display(Name = "Mobile")]
        [RegularExpression("^\\+?[1-9][0-9]{7,14}$", ErrorMessage = "Please Enter A Valid Mobile Number")]
        public string? MobileNo { get; set; } = "";

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
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
        public string? District { get; set; } = "";

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
        public string? OtherInstitute { get; set; } = "";

        [Display(Name = "Preffered Location")]
        [StringLength(30)]
        public string? PrefferedLocation { get; set; } = "";

        [Required]
        [Display(Name = "Are you ready to relocate?")]
        public bool? ReadyToRelocate { get; set; } = false;

        [Required]
        [Display(Name = "Total Experience (Months)")]
        public int? TotalExperience { get; set; }

        [Required]
        [Display(Name = "Job Category")]
        [StringLength(40)]
        public string? JobCategory { get; set; }

        [Display(Name = "Key Skills")]
        [StringLength(40)]
        public string? KeySkills { get; set; }

        [Display(Name = "Current Industry")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid Industry")]
        public string? CurrentIndustry { get; set; } = "";

        [Display(Name = "Current Employer")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid Employer")]
        public string? CurrentEmployer { get; set; } = "";

        [Display(Name = "Current Designation")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid Designation")]
        public string? CurrentDesignation { get; set; } = "";

        [Display(Name = "Previous Employer")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid Employer")]
        public string? PreviousEmployer { get; set; } = "";

        [Display(Name = "Previous Designation")]
        [StringLength(30)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please Enter A Valid Designation")]
        public string? PreviousDesignation { get; set; } = "";

        [Display(Name = "Notice Period")]
        [StringLength(15)]
        public string? NoticePeriod { get; set; } = "Immediately";

        [Display(Name = "CTC (per anum)")]
        public int? Ctc { get; set; } = 0;

        [Required]
        [Display(Name = "Resume Title")]
        [StringLength(25)]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Please Enter A Valid Resume Title")]
        public string? ResumeTitle { get; set; }

        public string? ResumePath { get; set; } = "";

        public string? Resume { get; set; } = "";

        public bool? IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime DeletedOn { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }

        [ForeignKey("StateId")]
        public virtual State? State { get; set; }

        [ForeignKey("CityId")]
        public virtual City? City { get; set; }

    }
}
