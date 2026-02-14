using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademyCQRS.Core.Application.Common.Results;

namespace MyAcademyCQRS.Core.Application.Features.Commands.ContactInfoCommands
{
    public class CreateContactInfoCommand : IRequest<Result>
    {
        public string BackgroundImageUrl { get; set; }
        public IFormFile File { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
        public string HolidayHours { get; set; }
    }
}