using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.GalleryImageQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultProjectViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
             => View(await mediator.Send(new GetActiveGalleryImageQuery()));
    }
}
