using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.GalleryImages;

namespace MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries
{
    public class GetGalleryImageByIdQuery
    : IRequest<GetGalleryImageByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
