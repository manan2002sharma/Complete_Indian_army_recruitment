using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class CandidateDocument
    {
        [Key]
        public Guid CandidateDocumentId { get; set; }

        [Required]
        public Guid ApplicationId { get; set; }  // Foreign key to Application

        [Required]
        public Guid RequiredDocumentId { get; set; }  // Foreign key to RequiredDocument

        [Required]
        public string FilePath { get; set; }
        public string? DocumentType { get; set; }
        public string? VerificationStatus { get; set; }
        public string? Remarks { get; set; }
        public DateTime? SubmissionDate { get; set; }

        // Navigation properties
        //public Application? Application { get; set; }
        //public RequiredDocument? RequiredDocument { get; set; }
        //public DocumentVerification? DocumentVerification { get; set; }

    }
}
