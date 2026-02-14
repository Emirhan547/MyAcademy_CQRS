using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactInfoQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ContactInfoResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class GetAllContactInfoQueryHandler(IRepository<ContactInfo> repository, IMapper mapper) : IRequestHandler<GetAllContactInfoQuery, IList<GetAllContactInfoQueryResult>>
    {
        public async Task<IList<GetAllContactInfoQueryResult>> Handle(GetAllContactInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            return mapper.Map<IList<GetAllContactInfoQueryResult>>(data);
        }
    }
}