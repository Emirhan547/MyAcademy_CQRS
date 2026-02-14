using MediatR;
using MyAcademyCQRS.Core.Application.Features.Results.ContactInfoResults;

namespace MyAcademyCQRS.Core.Application.Features.Queries.ContactInfoQueries
{
    public class GetContactInfoByIdQuery : IRequest<GetContactInfoByIdQueryResult>
    {
        public int Id { get; set; }
    }
}