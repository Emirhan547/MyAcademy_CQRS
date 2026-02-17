namespace MyAcademyCQRS.Areas.Admin.Models
{
    public class DashboardDailyRevenueItem
    {
        public string DayLabel { get; set; } = string.Empty;
        public decimal Revenue { get; set; }
    }
}
