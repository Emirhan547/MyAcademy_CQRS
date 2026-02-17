namespace MyAcademyCQRS.Areas.Admin.Models
{
    public class AdminDashboardViewModel
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
        public List<DashboardDailyRevenueItem> WeeklyRevenue { get; set; } = new();
        public List<DashboardRecentOrderItem> RecentOrders { get; set; } = new();
        public List<DashboardTopProductItem> TopProducts { get; set; } = new();
        public List<DashboardRecentMessageItem> RecentMessages { get; set; } = new();
    }
}
