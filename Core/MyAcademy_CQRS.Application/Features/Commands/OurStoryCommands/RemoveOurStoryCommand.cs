using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands
{
    public class RemoveOurStoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
