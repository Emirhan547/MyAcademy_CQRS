using MediatR;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries;


namespace MyAcademyCQRS.Core.Application.Features.Results.GalleryImages
{
    public class GetGalleryImageByIdQueryResult : IRequest<IList<GetGalleryImageByIdQuery>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
