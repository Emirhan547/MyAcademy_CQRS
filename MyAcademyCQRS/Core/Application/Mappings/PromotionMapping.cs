using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.PromotionCommands;
using MyAcademyCQRS.Core.Application.Features.Results.PromotionResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class PromotionMapping:Profile
    {
        public PromotionMapping()
        {
            CreateMap<CreatePromotionCommand, Promotion>();
            CreateMap<UpdatePromotionCommand, Promotion>();

            CreateMap<Promotion, GetAllPromotionsQueryResult>();
            CreateMap<Promotion, GetActivePromotionsQueryResult>();
        }
    }
}
