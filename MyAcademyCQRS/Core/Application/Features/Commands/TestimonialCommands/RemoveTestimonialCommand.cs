using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
