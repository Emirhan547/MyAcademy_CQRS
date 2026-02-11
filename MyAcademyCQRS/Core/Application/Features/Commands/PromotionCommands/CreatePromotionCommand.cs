using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands
{
    public class CreatePromotionCommand : IRequest<Result>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
