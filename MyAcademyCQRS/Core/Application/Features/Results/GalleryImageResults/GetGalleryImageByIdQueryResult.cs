using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.GallerImages;

namespace MyAcademyCQRS.Core.Application.Features.Results.GalleryImages
{
    public class GetGalleryImageByIdQueryResult : IRequest<IList<GetActiveGalleryImageQueryResult>>
    {
    }
}
