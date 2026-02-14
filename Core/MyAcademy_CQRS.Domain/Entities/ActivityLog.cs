using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Domain.Entities;

public class ActivityLog : BaseEntity
{
    public ActivityLogCategory Category { get; set; }
    public string Action { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? UserEmail { get; set; }
    public string? UserId { get; set; }
    public string? IpAddress { get; set; }
}