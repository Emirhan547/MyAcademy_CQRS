using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.PromotionQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultPromotionViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
             => View(await mediator.Send(new GetActivePromotionsQuery()));
    }
}
