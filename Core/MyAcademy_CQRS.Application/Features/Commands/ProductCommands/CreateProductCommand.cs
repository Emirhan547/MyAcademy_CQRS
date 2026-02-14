
using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands
{
    public class CreateProductCommand:IRequest<Result>
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
    }

}
