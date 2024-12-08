using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Indian_Army_Recruitment.Models
{
    public class RequiredDocument
    {
        [Key]
        public Guid RequiredDocumentId { get; set; }

        [Required]
        public Guid VacancyId { get; set; }

        [Required]
        [StringLength(100)]  // Limiting the document type length
        public string DocumentType { get; set; }

        [StringLength(500)]  // Limiting description length
        public string Description { get; set; }

        // Navigation property for one-to-many relationship
        //public Vacancy? Vacancy { get; set; }
        //public ICollection<CandidateDocument>? CandidateDocuments { get; set; }  

    }
}
