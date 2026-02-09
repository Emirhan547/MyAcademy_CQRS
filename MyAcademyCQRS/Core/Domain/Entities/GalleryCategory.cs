namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class GalleryCategory:BaseEntity
    {
        public string Name { get; set; }
        public IList<GalleryImage> Images { get; set; }
    }
}
