using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.ServiceQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ServiceResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler(
        IRepository<Service> _repository,
        IMapper _mapper)
        : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetServiceByIdQueryResult>(entity);
        }
    }
}