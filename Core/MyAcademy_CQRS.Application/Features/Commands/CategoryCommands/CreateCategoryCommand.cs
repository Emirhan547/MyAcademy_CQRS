using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands
{
    public class CreateCategoryCommand : IRequest<Result>
    {
        public string Name { get; set; }
    }
}
