namespace MyAcademyCQRS.Core.Application.Features.Results.GallerImages
{
    public class GetAllGalleryImageQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
