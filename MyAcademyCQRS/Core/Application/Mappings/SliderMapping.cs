using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class SliderMapping:Profile
    {
        public SliderMapping()
        {
            // Create
            CreateMap<CreateSliderCommand, Slider>();

            // Query result
            CreateMap<Slider, SliderListResult>();
        }
    }
}
