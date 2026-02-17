using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.DashboardResults
{
    public class DashboardRecentMessageResult
    {
        public string FullName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
