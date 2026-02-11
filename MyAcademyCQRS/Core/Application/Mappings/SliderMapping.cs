using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands;
using MyAcademyCQRS.Core.Application.Features.Commands.SliderCommands;
using MyAcademyCQRS.Core.Application.Features.Results.FeatureResults;
using MyAcademyCQRS.Core.Application.Features.Results.SliderResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class SliderMapping:Profile
    {
        public SliderMapping()
        {
            CreateMap<CreateSliderCommand, Slider>();
            CreateMap<UpdateSliderCommand, Slider>();
            CreateMap<Slider, GetAllSlidersQueryResult>();
            CreateMap<Slider, GetActiveSlidersQueryResult>();

        }
    }
}
