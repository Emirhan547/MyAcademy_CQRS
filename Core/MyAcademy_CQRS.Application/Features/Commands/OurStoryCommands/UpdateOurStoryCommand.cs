using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands
{
    public class UpdateOurStoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? File { get; set; }
        public bool IsActive { get; set; }
    }
}
