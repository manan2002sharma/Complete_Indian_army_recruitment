using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class VacancyExam
    {

        [Key]
        public Guid ExamId { get; set; }

        [Required]
        public Guid VacancyId { get; set; } // Foreign key for Vacancy

        [Required]
        public DateTime ExamDate { get; set; }

        [Range(0, int.MaxValue)]
        public int TotalMarks { get; set; }

        [Range(0, int.MaxValue)]
        public int PassingCriteria { get; set; }
        public string? ExamName { get; set; }

        //public Vacancy? Vacancy { get; set; } // Navigation property for Vacancy

        //public ICollection<VacancyExamResult>? VacancyExamResults { get; set; } // Navigation property for VacancyExamResult

    }
}
