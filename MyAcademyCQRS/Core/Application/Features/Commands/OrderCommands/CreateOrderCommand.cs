using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Commands.OrderItemCommands;

namespace MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Result>
    {
        public IList<CreateOrderItemCommand> Items { get; set; } = new List<CreateOrderItemCommand>();
    }

  

}
