using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.GallerImageCommands
{
    public class UpdateGalleryImageCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
