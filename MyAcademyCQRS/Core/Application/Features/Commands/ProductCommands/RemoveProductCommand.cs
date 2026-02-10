using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands
{
    public class RemoveProductCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }

}
