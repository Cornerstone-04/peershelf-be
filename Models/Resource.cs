namespace AcademicResourceApp.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public string Type { get; set; }
        public DateTime UploadedAt { get; set; }
        public Guid? UploadedById { get; set; }
        public User UploadedBy { get; set; }
    }
}
