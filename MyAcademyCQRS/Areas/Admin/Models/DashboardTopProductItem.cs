namespace MyAcademyCQRS.Areas.Admin.Models
{
    public class DashboardTopProductItem
    {
        public string Name { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Rating { get; set; }
    }
}
