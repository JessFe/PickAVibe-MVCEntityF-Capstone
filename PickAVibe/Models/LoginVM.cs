using System.ComponentModel.DataAnnotations;

namespace PickAVibe.Models
{
    public class LoginVM
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string UsernameOrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}