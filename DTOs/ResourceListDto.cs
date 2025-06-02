namespace AcademicResourceApp.DTOs
{
    public class ResourceListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CourseCode { get; set; }
        public string Author { get; set; }
        public string Format { get; set; }
        public string Department { get; set; }
        public string Level { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public DateTime UploadedAt { get; set; }
        public string? ImageUrl { get; set; }
    }


}
