using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers2
{
    public class GetActiveCategoriesQueryHandler(IRepository<Category> _repository, IMapper _mapper) : IRequestHandler<GetActiveCategoriesQuery, IList<GetActiveCategoriesQueryResult>>
    {
        public async Task<IList<GetActiveCategoriesQueryResult>> Handle(GetActiveCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            var active = categories.Where(x => x.IsActive).ToList();
            return _mapper.Map<IList<GetActiveCategoriesQueryResult>>(active);
        }
    }
}
