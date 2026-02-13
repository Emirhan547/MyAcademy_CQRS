using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.FeatureQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultFeatureViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
             => View(await mediator.Send(new GetActiveFeaturesQuery()));
    }
}
