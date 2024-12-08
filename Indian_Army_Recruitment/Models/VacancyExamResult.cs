using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class VacancyExamResult
    {
        [Key]
        public Guid ExamResultId { get; set; }

        [Required]
        public Guid ExamId { get; set; } // Foreign key for VacancyExam

        [Required]
        public Guid ApplicationId { get; set; } // Foreign key for Application

        [Range(0, int.MaxValue)]
        public int Score { get; set; }

        [StringLength(20)]
        public string ResultStatus { get; set; } // Pass/Fail/Other
        public string? ExamName { get; set; }

        //public VacancyExam VacancyExam { get; set; } // Navigation property for VacancyExam

        //public Application Application { get; set; } // Navigation property for Application

    }
}
