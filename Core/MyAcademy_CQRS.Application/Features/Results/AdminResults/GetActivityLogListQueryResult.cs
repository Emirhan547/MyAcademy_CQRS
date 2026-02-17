using MyAcademyCQRS.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.AdminResults
{
    public class GetActivityLogListQueryResult
    {
        public ActivityLogCategory? SelectedCategory { get; set; }
    public List<ActivityLogListItemResult> Logs { get; set; } = new();
    }
}
