using System.ComponentModel.DataAnnotations;

namespace AcademicResourceApp.DTOs
{
    public class RegisterDto
    {

        [Required]
        public string FirstName { get; set; }

        [Required] 
        public string LastName { get; set;}

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password do not match")]
        public string PasswordConfirmation { get; set; }

        // this is based on the user having a student email or not.
        [EmailAddress]
        public string? SchoolEmail { get; set; }

    }
}
