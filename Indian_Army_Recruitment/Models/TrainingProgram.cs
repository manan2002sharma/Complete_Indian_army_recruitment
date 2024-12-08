using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class TrainingProgram
    {
        [Key]
        public Guid TrainingId { get; set; }
        [Required]
        public Guid ApplicationId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Location cannot exceed 200 characters.")]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required]
        public string TrainerName { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
        public string Content { get; set; }
        public string? status { get; set; }
        public string? Remark { get; set; }
        //public Application? Application { get; set; }

    }
}
