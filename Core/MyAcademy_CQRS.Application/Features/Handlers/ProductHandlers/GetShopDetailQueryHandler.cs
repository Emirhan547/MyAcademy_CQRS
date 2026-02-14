using AutoMapper;
using MediatR;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Features.Handlers.ProductHandlers
{
    public class GetShopDetailQueryHandler(
        IRepository<Product> productRepository,
        IRepository<Category> categoryRepository,
        IMapper mapper)
        : IRequestHandler<GetShopDetailQuery, GetShopDetailQueryResult>
    {
        public async Task<GetShopDetailQueryResult> Handle(GetShopDetailQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllAsync();
            var product = products.FirstOrDefault(x => x.Id == request.Id && x.IsActive);

            if (product is null)
            {
                return null;
            }

            var categories = await categoryRepository.GetAllAsync();
            var categoryName = categories.FirstOrDefault(x => x.Id == product.CategoryId)?.Name ?? "Category";

            var relatedProducts = products
                .Where(x => x.IsActive && x.CategoryId == product.CategoryId && x.Id != product.Id)
                .Take(4)
                .ToList();

            return new GetShopDetailQueryResult
            {
                Product = mapper.Map<GetProductByIdQueryResult>(product),
                CategoryName = categoryName,
                RelatedProducts = mapper.Map<IList<GetActiveProductsQueryResult>>(relatedProducts)
            };
        }
    }
}