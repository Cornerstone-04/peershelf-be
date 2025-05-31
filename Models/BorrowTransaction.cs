namespace AcademicResourceApp.Models
{
    public class BorrowTransaction
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public Guid BorrowerId { get; set; }
        public User Borrower { get; set; }
        public string Status { get; set; } = "pending"; // Pending, Approved, Rejected, Returned
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }  // when the resource should be returned
        public DateTime? ReturnedDate { get;set; }  // when it was returned
    }
}
