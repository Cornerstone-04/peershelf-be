using System.ComponentModel.DataAnnotations;

namespace AcademicResourceApp.DTOs
{
    public class RegisterDto
    {

        [Required]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string MatricNumber { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password do not match")]
        public string PasswordConfirmation { get; set; }

    }
}
