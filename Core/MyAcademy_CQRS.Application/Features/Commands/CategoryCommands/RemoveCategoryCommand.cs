using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands
{
    public class RemoveCategoryCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
