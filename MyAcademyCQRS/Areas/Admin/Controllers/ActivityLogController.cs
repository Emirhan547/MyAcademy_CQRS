using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademyCQRS.Areas.Admin.Models;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ActivityLogController(AppDbContext context) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index(ActivityLogCategory? category)
    {
        var query = context.ActivityLogs
            .AsNoTracking()
            .Where(x => x.IsActive);

        if (category.HasValue)
        {
            query = query.Where(x => x.Category == category.Value);
        }

        var logs = await query
            .OrderByDescending(x => x.CreatedDate)
            .Take(500)
            .ToListAsync();

        var model = new ActivityLogListViewModel
        {
            Logs = logs,
            SelectedCategory = category
        };

        return View(model);
    }
}