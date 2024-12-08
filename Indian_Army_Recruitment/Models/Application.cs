using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class Application
    {
        [Key]
        public Guid ApplicationId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid VacancyId { get; set; }

        public string? ApplicationStatus { get; set; }

        public DateTime? SubmissionDate { get; set; }

        public bool? DocumentSubmitted { get; set; }

        public string? VacancyName { get; set; }
        //public User? User { get; set; }

        //public Vacancy? Vacancy { get; set; }
        //public ICollection<VacancyExamResult>? VacancyExamResults { get; set; }
        //public ICollection<Test>? Tests { get; set; }
        //public ICollection<CandidateDocument> CandidateDocuments { get; set; }
        //public ICollection<TrainingProgram>? TrainingPrograms { get; set; }
    }
}
