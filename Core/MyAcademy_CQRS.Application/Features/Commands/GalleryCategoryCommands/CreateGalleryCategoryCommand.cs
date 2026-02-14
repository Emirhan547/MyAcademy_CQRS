using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.GalleryCategoryCommands
{
    public class CreateGalleryCategoryCommand : IRequest<Result>
    {
        public string Name { get; set; }
    }
}
