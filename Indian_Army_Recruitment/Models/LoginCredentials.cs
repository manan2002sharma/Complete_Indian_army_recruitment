using System.ComponentModel.DataAnnotations;

namespace Indian_Army_Recruitment.Models
{
    public class LoginCredentials
    {

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
        [Required]
        public string deviceinfo { get; set; }
    }
}
