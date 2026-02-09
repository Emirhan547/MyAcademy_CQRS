namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class Slider:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string ProductImageUrl { get; set; }
        public int DisplayOrder { get; set; }
    }
}
