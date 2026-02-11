using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Application.Features.Queries.SliderQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
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
            var sliders = await _mediator.Send(new GetAllSlidersQuery());
            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSliderCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(command);
            }

            TempData["Success"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var slider = await _mediator.Send(new GetSliderByIdQuery { Id = id});

            if (slider is null)
                return NotFound();

            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateSliderCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Success)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View(command);
            }

       
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _mediator.Send(new RemoveSliderCommand(id));

            if (!result.Success)
                TempData["Error"] = result.Message;
            else
                TempData["Success"] = result.Message;

            return RedirectToAction(nameof(Index));
        }

    }
}
