using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ContactMessages;
using MyAcademyCQRS.Core.Application.Features.Results.ContactMessageResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Mappings
{
    public class ContactMessageMapping:Profile
    {
        public ContactMessageMapping()
        {
            CreateMap<CreateContactMessageCommand, ContactMessage>();
            CreateMap<UpdateContactCommand, ContactMessage>();
            CreateMap<ContactMessage, GetAllContactMessagesQueryResult>();
            CreateMap<ContactMessage, GetContactMessageByIdQueryResult>();
        }
    }
}
