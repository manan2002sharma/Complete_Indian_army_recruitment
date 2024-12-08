using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class Test
    {
        [Key]
        public Guid TestId { get; set; }

        [Required]
        public Guid ApplicationId { get; set; }

        [Required]
        [StringLength(20)]
        public string TestType { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        public string? Status { get; set; }
        public string? Remarks { get; set; }

        //public Application? Application { get; set; }
    }
}
