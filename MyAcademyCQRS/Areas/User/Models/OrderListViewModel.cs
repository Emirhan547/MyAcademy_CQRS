using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Areas.User.Models
{
    public class OrderListViewModel
    {
        public List<Order> Orders { get; set; } = [];
    }
}
