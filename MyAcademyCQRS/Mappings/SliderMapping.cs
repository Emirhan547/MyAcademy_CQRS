using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Sliders.Dtos;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Mappings
{
    public class SliderMapping:Profile
    {
        public SliderMapping()
        {
            CreateMap<SliderCreateDto, Slider>();
            CreateMap<Slider, SliderListDto>();
        }
    }
}
