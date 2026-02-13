using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.GalleryImageCommands
{
    public class RemoveGalleryImageCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

}
