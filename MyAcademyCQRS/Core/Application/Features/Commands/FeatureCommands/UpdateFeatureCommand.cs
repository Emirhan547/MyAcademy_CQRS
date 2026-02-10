using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands
{
    public class UpdateFeatureCommand:IRequest<Result>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
