using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands
{
    public class RemoveNewsCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}