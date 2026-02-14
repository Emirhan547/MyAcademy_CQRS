using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ServiceCommands;
using MyAcademyCQRS.Core.Application.Features.Results.ServiceResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class ServiceMapping:Profile
    {
        public ServiceMapping()
        {
            CreateMap<CreateServiceCommand, Service>();
            CreateMap<UpdateServiceCommand, Service>();
            CreateMap<Service, GetAllServicesQueryResult>();
            CreateMap<Service, GetActiveServicesQueryResult>();
            CreateMap<Service, GetServiceByIdQueryResult>();
        }
    }
}
