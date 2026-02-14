namespace MyAcademyCQRS.Core.Domain.Entities
{
    public class GalleryImage:BaseEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public int GalleryCategoryId { get; set; }
        public GalleryCategory GalleryCategory { get; set; }
    }
}
