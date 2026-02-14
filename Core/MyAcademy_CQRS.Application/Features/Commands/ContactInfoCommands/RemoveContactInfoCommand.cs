using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands
{
    public class RemoveContactInfoCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}