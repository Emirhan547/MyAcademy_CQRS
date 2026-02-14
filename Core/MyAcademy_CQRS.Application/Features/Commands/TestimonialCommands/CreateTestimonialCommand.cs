using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands
{
    public class CreateTestimonialCommand : IRequest<Result>
    {
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Comment { get; set; }
    }
}
