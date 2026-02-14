using MyAcademyCQRS.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Contracts.Services
{
    public interface IActivityLogService
    {
        Task LogAsync(
        ActivityLogCategory category,
        string action,
        string? description = null,
        string? userEmail = null,
        string? userId = null,
        string? ipAddress = null,
        CancellationToken cancellationToken = default);
    }
}
