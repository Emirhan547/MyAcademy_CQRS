using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands
{
    public class CreateGalleryImageCommand : IRequest<Result>
    {
        public int GalleryCategoryId { get; set; }
        public string Title { get; set; }
        public IFormFile File { get; set; }
    }
}
