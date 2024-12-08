using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Indian_Army_Recruitment.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [RegularExpression(@"^(Admin|Recruiter|Candidate|Medical Officer)$", ErrorMessage = "Role must be one of the following: Admin, Recruiter, Candidate, Medical Officer")]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? LastLogin { get; set; }
        //public CandidateProfile? CandidateProfile { get; set; }
        //public ICollection<PlatformAccess>? PlatformAccesses { get; set; }

        //public ICollection<Vacancy>? Vacancies { get; set; }
        //public ICollection<Application>? Applications { get; set; }
    }
}
