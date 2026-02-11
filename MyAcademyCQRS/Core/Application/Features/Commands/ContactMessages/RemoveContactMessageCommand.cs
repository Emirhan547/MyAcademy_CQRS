using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages
{
    public class RemoveContactMessageCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
