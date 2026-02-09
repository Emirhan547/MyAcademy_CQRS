namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class OurStory:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
    }
}
