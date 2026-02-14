using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands
{
    public class RemoveFeatureCommand : IRequest<Result>
    {
        public int Id { get; set; }
    }
}
