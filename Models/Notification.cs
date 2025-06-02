namespace AcademicResourceApp.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public Guid UserId { get; set; } // Who receives the notification
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
        public User User { get; set; }
    }
}

