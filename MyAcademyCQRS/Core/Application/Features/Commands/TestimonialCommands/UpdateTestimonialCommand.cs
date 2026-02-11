using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands
{
    public class UpdateTestimonialCommand : IRequest<Result>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
