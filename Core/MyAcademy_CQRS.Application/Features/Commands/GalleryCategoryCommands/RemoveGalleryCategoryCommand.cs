using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands
{
    public class RemoveGalleryCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
