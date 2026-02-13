namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class ContactInfo : BaseEntity
    {
        public string BackgroundImageUrl { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
        public string HolidayHours { get; set; }
    }
}
