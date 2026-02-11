using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.GallerImages;

namespace MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries
{
    public class GetActiveGalleryImageQuery : IRequest<IList<GetActiveGalleryImageQueryResult>>
    {
    }
}
