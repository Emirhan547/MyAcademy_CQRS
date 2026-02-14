using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands
{
    public class UpdateNewsCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile? File { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; }
    }
}