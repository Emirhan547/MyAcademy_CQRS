using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultShopViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
            => View(await mediator.Send(new GetActiveProductsQuery()));
    }
}
