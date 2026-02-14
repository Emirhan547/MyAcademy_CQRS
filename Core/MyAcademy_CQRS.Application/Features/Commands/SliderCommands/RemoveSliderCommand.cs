using MediatR;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands
{
    public class RemoveSliderCommand : IRequest<Result>
    {
        public RemoveSliderCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

       
    }
}