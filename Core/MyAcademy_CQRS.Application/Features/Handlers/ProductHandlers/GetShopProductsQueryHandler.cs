using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Features.Handlers.ProductHandlers
{
    public class GetShopProductsQueryHandler(
        IRepository<Product> repository,
        IMapper mapper)
        : IRequestHandler<GetShopProductsQuery, IList<GetActiveProductsQueryResult>>
    {
        public async Task<IList<GetActiveProductsQueryResult>> Handle(GetShopProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();

            var filtered = products
                .Where(x => x.IsActive && (!request.CategoryId.HasValue || x.CategoryId == request.CategoryId.Value))
                .ToList();

            return mapper.Map<IList<GetActiveProductsQueryResult>>(filtered);
        }
    }
}