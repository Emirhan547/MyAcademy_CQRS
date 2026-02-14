using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands
{
    public class RemoveServiceCommand:IRequest<Result>
    {
        public int Id { get; set; }
    }
}
