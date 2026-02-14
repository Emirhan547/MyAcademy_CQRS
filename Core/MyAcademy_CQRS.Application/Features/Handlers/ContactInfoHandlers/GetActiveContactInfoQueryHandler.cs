using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ContactInfoQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ContactInfoResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ContactInfoHandlers
{
    public class GetActiveContactInfoQueryHandler(IRepository<ContactInfo> repository, IMapper mapper) : IRequestHandler<GetActiveContactInfoQuery, GetActiveContactInfoQueryResult>
    {
        public async Task<GetActiveContactInfoQueryResult> Handle(GetActiveContactInfoQuery request, CancellationToken cancellationToken)
        {
            var data = await repository.GetAllAsync();
            var active = data.Where(x => x.IsActive).OrderByDescending(x => x.Id).FirstOrDefault();
            return active is null ? null : mapper.Map<GetActiveContactInfoQueryResult>(active);
        }
    }
}