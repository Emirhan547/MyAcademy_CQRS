using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.OurStoryQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultOurStoryViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
              => View(await mediator.Send(new GetActiveOurStoryQuery()));
    }
}
