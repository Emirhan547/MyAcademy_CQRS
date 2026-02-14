using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands
{
    public class UpdatePromotionCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }
    }
}
