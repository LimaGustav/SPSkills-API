using System.ComponentModel.DataAnnotations;

namespace API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter a valid email")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Enter the users password")]
        public string? Password { get; set; }
    }
}
