using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Results.DashboardResults
{
    public class GetAdminDashboardQueryResult
    {
        public int TotalOrderCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public int ActiveProductCount { get; set; }
        public int ActiveMessageCount { get; set; }
        public int PendingOrderCount { get; set; }
        public int ApprovedOrderCount { get; set; }
        public int CancelledOrderCount { get; set; }
        public int NewOrdersToday { get; set; }
        public decimal TodayRevenue { get; set; }
        public List<DashboardDailyRevenueResult> WeeklyRevenue { get; set; } = new();
        public List<DashboardRecentOrderResult> RecentOrders { get; set; } = new();
        public List<DashboardTopProductResult> TopProducts { get; set; } = new();
        public List<DashboardRecentMessageResult> RecentMessages { get; set; } = new();
    }
}
