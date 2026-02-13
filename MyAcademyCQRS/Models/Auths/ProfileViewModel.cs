using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Models.Auths
{
    public class ProfileViewModel
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = [];
    }
}
