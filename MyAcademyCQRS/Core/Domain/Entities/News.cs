namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
    }
}