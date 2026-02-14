using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.NewsCommands;
using MyAcademyCQRS.Core.Application.Features.Results.NewsResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class NewsMapping : Profile
    {
        public NewsMapping()
        {
            CreateMap<CreateNewsCommand, News>();
            CreateMap<UpdateNewsCommand, News>();
            CreateMap<News, GetAllNewsQueryResult>();
            CreateMap<News, GetActiveNewsQueryResult>();
            CreateMap<News, GetNewsByIdQueryResult>();
        }
    }
}