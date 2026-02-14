

namespace MyAcademyCQRS.Core.Application.Features.Results.GalleryImages
{
    public class GetActiveGalleryImageQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<GetAllGalleryImageQueryResult> Images { get; set; }
    }
}
