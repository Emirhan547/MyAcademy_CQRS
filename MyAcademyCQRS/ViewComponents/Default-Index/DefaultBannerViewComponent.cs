using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultBannerViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await mediator.Send(new GetActiveSlidersQuery());
            return View(data.OrderBy(x => x.DisplayOrder).ToList());
        }
    }
}
