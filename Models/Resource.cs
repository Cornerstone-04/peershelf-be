namespace AcademicResourceApp.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }  //Cloudinary URL
        public string Type { get; set; } // Pdf, Hardcopy
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public Guid UploadedById { get; set; }
        public User UploadedBy { get; set; }
    }
}
