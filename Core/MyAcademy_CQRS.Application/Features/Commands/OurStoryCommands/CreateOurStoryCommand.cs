using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands
{
    public class CreateOurStoryCommand : IRequest<Result>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
