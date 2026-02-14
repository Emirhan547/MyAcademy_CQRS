

using AutoMapper;
using MediatR;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class GetAllCategoriesQueryHandler(IRepository<Category> _repository, IMapper _mapper) : IRequestHandler<GetAllCategoriesQuery, IList<GetAllCategoriesQueryResult>>
    {
        public async Task<IList<GetAllCategoriesQueryResult>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repository.GetAllAsync();
            return _mapper.Map<IList<GetAllCategoriesQueryResult>>(categories);
        }
    }
}

