using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands
{
    public class RemovePromotionCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
