using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands;
using MyAcademyCQRS.Core.Application.Features.Results.ContactInfoResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class ContactInfoMapping : Profile
    {
        public ContactInfoMapping()
        {
            CreateMap<CreateContactInfoCommand, ContactInfo>();
            CreateMap<UpdateContactInfoCommand, ContactInfo>();
            CreateMap<ContactInfo, GetAllContactInfoQueryResult>();
            CreateMap<ContactInfo, GetActiveContactInfoQueryResult>();
            CreateMap<ContactInfo, GetContactInfoByIdQueryResult>();
        }
    }
}