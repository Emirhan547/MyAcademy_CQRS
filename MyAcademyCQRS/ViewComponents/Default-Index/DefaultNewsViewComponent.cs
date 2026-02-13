using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.NewsQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultNewsViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
             => View(await mediator.Send(new GetActiveNewsQuery()));
    }
}
