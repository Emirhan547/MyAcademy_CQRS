using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Sliders.Commands;
using MyAcademyCQRS.Core.Application.Features.Sliders.Dtos;
using MyAcademyCQRS.Core.Application.Features.Sliders.Queries;

namespace MyAcademyCQRS.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly IMediator _mediator;

        public SliderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _mediator.Send(new GetAdminSlidersQuery());
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateDto dto)
        {
            var result = await _mediator.Send(new CreateSliderCommand(dto));
            return result.Success ? Ok() : BadRequest(result.Errors);
        }
    }
}
