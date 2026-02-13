using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.ServiceQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultServiceViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
             => View(await mediator.Send(new GetActiveServicesQuery()));
    }
}
