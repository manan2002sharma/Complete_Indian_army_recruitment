using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class CandidateProfile
    {

        [Key]
        public Guid UserId { get; set; } // Primary key is also the foreign key

        [Required]
        public string FullName { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        public string Qualifications { get; set; }
        public string Experience { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public string MilitaryBackground { get; set; }
        public string? State { get; set; }

        //public User? User { get; set; }

    }
}
