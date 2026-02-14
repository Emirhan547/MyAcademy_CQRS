using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ServiceQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ServiceResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ServiceHandlers
{
    public class GetActiveServicesQueryHandler (IRepository<Service>_repository,IMapper _mapper): IRequestHandler<GetActiveServicesQuery, IList<GetActiveServicesQueryResult>>
    {
        public async Task<IList<GetActiveServicesQueryResult>> Handle(
             GetActiveServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _repository.GetAllAsync();
            var active = services.Where(x => x.IsActive).ToList();
            return _mapper.Map<IList<GetActiveServicesQueryResult>>(active);
        }
    }
}
