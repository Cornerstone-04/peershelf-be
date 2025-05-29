using CloudinaryDotNet.Actions;

namespace AcademicResourceApp.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } = "student";

        public List<Resource> Resources { get; set; }
        public List<BorrowTransaction> BorrrowedResources { get; set; }

    }
}
