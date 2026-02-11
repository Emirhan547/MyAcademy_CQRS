namespace MyAcademyCQRS.Core.Application.Features.Results.TestimonialResults
{
    public class GetAllTestimonialsQueryResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
