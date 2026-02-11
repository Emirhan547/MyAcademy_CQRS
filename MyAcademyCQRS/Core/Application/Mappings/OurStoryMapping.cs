using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.OurStoryCommands;
using MyAcademyCQRS.Core.Application.Features.Results.OurStoryResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class OurStoryMapping:Profile
    {
        public OurStoryMapping()
        {
            CreateMap<CreateOurStoryCommand, OurStory>();
            CreateMap<UpdateOurStoryCommand, OurStory>();

            CreateMap<OurStory, GetActiveOurStoryQueryResult>();
            CreateMap<OurStory, GetOurStoryByIdQueryResult>();
        }
    }
}
