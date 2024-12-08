using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class DocumentVerification
    {
        [Key]
        public Guid VerificationId { get; set; }

        [Required]
        public Guid CandidateDocumentID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Document type cannot exceed 100 characters.")]
        public string DocumentType { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Verification status cannot exceed 50 characters.")]
        public string VerificationStatus { get; set; }

        [StringLength(500, ErrorMessage = "Remarks cannot exceed 500 characters.")]
        public string Remarks { get; set; }

        //public CandidateDocument? CandidateDocument { get; set; }
    }
}
