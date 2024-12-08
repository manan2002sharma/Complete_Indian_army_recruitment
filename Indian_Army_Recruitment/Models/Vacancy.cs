using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class Vacancy
    {
        [Key]
        public Guid VacancyId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; }

        [Required]
        public string EligibilityCriteria { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Range(0, double.MaxValue)]
        public int Salary { get; set; }

        public Guid PostedBy { get; set; }
        public DateTime DatePosted { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; }

        //public User? PostedByUser { get; set; }

        //public ICollection<Application>? Applications { get; set; }
        //public ICollection<VacancyAnalysis>? VacancyAnalysis { get; set; }
        //public ICollection<RequiredDocument>? RequiredDocuments { get; set; }
        //public ICollection<VacancyExam>? VacancyExams { get; set; } 
    }
}
