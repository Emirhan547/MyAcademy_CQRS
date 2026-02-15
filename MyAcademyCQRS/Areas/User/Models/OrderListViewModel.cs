using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Areas.User.Models
{
    public class OrderListViewModel
    {
        public IList<Order> Orders { get; set; } = [];
    }
}
