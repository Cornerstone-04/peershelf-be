namespace AcademicResourceApp.Models
{
    public class BorrowTransaction
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public Guid BorrowerId { get; set; }
        public User Borrower { get; set; }

        public BorrowStatus Status { get; set; } = BorrowStatus.Pending;

        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
    }
}
