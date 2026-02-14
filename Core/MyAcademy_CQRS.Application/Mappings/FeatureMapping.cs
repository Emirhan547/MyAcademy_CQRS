using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.FeatureCommands;
using MyAcademyCQRS.Core.Application.Features.Results.FeatureResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class FeatureMapping:Profile
    {
        public FeatureMapping() 
        {
            CreateMap<CreateFeatureCommand, Feature>();
            CreateMap<UpdateFeatureCommand, Feature>();
            CreateMap<Feature, GetAllFeaturesQueryResult>();
            CreateMap<Feature, GetActiveFeaturesQueryResult>();
            CreateMap<Feature, GetFeatureByIdQueryResult>();
        }
    }
}
