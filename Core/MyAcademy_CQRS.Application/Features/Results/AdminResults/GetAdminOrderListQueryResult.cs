using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.AdminResults
{
    public class GetAdminOrderListQueryResult
    {
        public string? SearchTerm { get; set; }
        public string? Status { get; set; }
        public int TotalOrderCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<AdminOrderListItemResult> Orders { get; set; } = new();
    }
}
