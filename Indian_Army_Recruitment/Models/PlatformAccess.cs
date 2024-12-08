using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class PlatformAccess
    {
        [Key]
        public Guid PlatformId { get; set; }

        [Required]
        public string userName { get; set; }

        [Required]
        public string deviceinfo { get; set; }

        public DateTime accessDate { get; set; }

        //public User? User { get; set; }
    }
}
