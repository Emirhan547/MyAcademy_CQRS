using Microsoft.AspNetCore.Identity;

namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
