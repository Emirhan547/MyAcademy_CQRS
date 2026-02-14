using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ServiceQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ServiceResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ServiceHandlers
{
    public class GetAllServicesQueryHandler(IRepository<Service>_repository,IMapper _mapper) : IRequestHandler<GetAllServicesQuery, IList<GetAllServicesQueryResult>>
    {
        public async Task<IList<GetAllServicesQueryResult>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _repository.GetAllAsync();
            return _mapper.Map<IList<GetAllServicesQueryResult>>(services);
        }
    }
}
