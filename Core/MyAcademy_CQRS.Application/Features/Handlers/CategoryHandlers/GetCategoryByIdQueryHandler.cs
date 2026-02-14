using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.CategoryQueries;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler(
        IRepository<Category> _repository,
        IMapper _mapper)
        : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            return entity is null
                ? null
                : _mapper.Map<GetCategoryByIdQueryResult>(entity);
        }
    }
}