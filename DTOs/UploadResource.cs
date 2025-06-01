namespace AcademicResourceApp.DTOs
{
    public class UploadResourceDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Type { get; set; } // e.g., "Pdf", "Hardcopy"
        public IFormFile File { get; set; } // For file upload
    }
}
