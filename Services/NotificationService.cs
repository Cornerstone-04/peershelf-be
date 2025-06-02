using AcademicResourceApp.Data;
using AcademicResourceApp.Models;

namespace AcademicResourceApp.Services
{
    public class NotificationService
    {
        private readonly AppDbContext _context;
        public NotificationService(AppDbContext context) => _context = context;

        public async Task NotifyAsync(Guid userId, string message)
        {
            var notification = new Notification { UserId = userId, Message = message };
            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }
    }
}
