using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactInfoQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultContactViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
            => View(await mediator.Send(new GetActiveContactInfoQuery()));
    }
}
