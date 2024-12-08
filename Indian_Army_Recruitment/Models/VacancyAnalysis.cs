using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class VacancyAnalysis
    {
        public Guid ReportId { get; set; }

        public Guid VacancyId { get; set; } // Foreign key to Vacancy
        public string VacancyName { get; set; }
        public DateTime DateGenerated { get; set; }
        public string PostedBy { get; set; }
        public ExamResultAnalysis[] ResultAnalysis { get; set; }
        public double SuccessRate { get; set; }

        public StatusResult[] Status {  get; set; }
        public StateResult[] States { get; set; }


        //public Vacancy? Vacancy { get; set; } // Navigation property
    }
}
