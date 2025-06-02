using System.ComponentModel.DataAnnotations;

namespace AcademicResourceApp.DTOs
{
    public class UploadResourceDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string CourseCode { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Format { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Level { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        [Required]
        public IFormFile File { get; set; }

        // Hardcover-specific fields
        public string? PhysicalLocation { get; set; }
        public string? MeetupLocation { get; set; }
        public IFormFile? Image { get; set; } // For uploaded image
    }
}
