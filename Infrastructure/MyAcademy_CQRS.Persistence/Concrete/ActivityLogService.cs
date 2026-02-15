using MyAcademy_CQRS.Application.Contracts.Services;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademy_CQRS.Persistence.Concrete
{
    public class ActivityLogService(AppDbContext context) : IActivityLogService
    {
        public async Task LogAsync(ActivityLogCategory category, string action, string? description = null, string? userEmail = null, string? userId = null, string? ipAddress = null, CancellationToken cancellationToken = default)
        {
            var log = new ActivityLog
            {
                Category = category,
                Action = action,
                Description = description,
                UserEmail = userEmail,
                UserId = userId,
                IpAddress = ipAddress,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            await context.ActivityLogs.AddAsync(log, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
