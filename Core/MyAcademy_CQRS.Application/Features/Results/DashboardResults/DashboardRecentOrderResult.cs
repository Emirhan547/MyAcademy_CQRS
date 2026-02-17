using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.DashboardResults
{
    public class DashboardRecentOrderResult
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
