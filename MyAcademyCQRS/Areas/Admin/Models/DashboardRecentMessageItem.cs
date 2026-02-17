namespace MyAcademyCQRS.Areas.Admin.Models
{
    public class DashboardRecentMessageItem
    {
        public string FullName { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
