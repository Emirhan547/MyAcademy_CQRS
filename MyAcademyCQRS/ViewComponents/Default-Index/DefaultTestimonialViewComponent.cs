using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Queries.TestimonialQueries;

namespace MyAcademyCQRS.ViewComponents.Default_Index
{
    public class DefaultTestimonialViewComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
             => View(await mediator.Send(new GetActiveTestimonialsQuery()));
    }
}
