using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands
{
    public class RemoveGalleryImageCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

}
