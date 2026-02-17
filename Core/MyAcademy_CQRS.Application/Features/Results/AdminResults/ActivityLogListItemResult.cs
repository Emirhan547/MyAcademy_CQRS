using MyAcademyCQRS.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.AdminResults
{
    public class ActivityLogListItemResult
    {
        public DateTime CreatedDate { get; set; }
        public ActivityLogCategory Category { get; set; }
        public string Action { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? UserEmail { get; set; }
    }
}
