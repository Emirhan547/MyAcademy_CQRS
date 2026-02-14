using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands
{
    public class CreateSliderCommand:IRequest<Result>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BackgroundImageUrl { get; set; }
        public string ProductImageUrl { get; set; }
        public IFormFile BackgroundImageFile { get; set; }
        public IFormFile ProductImageFile { get; set; }
        public int DisplayOrder { get; set; }
    }
}
