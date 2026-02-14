using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.Admin.Models;

public class ActivityLogListViewModel
{
    public List<ActivityLog> Logs { get; set; } = [];
    public ActivityLogCategory? SelectedCategory { get; set; }
}