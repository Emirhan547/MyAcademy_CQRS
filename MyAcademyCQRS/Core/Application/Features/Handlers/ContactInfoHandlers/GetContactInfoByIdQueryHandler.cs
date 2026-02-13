using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactInfoQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ContactInfoResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class GetContactInfoByIdQueryHandler(IRepository<ContactInfo> repository, IMapper mapper) : IRequestHandler<GetContactInfoByIdQuery, GetContactInfoByIdQueryResult>
    {
        public async Task<GetContactInfoByIdQueryResult> Handle(GetContactInfoByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIdAsync(request.Id);
            return entity is null ? null : mapper.Map<GetContactInfoByIdQueryResult>(entity);
        }
    }
}