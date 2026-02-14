namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class Testimonial:BaseEntity
    {
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Comment { get; set; }
    }
}
