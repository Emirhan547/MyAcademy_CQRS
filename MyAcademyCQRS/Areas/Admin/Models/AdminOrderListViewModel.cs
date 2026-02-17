namespace MyAcademyCQRS.Areas.Admin.Models
{
    public class AdminOrderListViewModel
    {
        public string? SearchTerm { get; set; }
        public string? Status { get; set; }
        public int TotalOrderCount { get; set; }
        public decimal TotalRevenue { get; set; }
        public List<AdminOrderListItemViewModel> Orders { get; set; } = new();
    }
}
