using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Domain.Enums;

namespace MyAcademyCQRS.Core.Application.Features.Commands.OrderCommands
{
    public class UpdateOrderStatusCommand : IRequest<Result>
    {
        public int OrderId { get; set; }
        public OrderStatus Status { get; set; }
    }

}
