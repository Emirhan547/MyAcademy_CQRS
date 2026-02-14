using MediatR;
using Microsoft.AspNetCore.Http;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademy_CQRS.Application.Features.Results.CartResults;
using MyAcademyCQRS.Core.Application.Common.Results;
using MyAcademyCQRS.Core.Application.Features.Queries.CartQueries;
using MyAcademyCQRS.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAcademy_CQRS.Application.Features.Handlers.CartHandlers
{
    public class GetCartQueryHandler(
         IRepository<Product> productRepository,
         IHttpContextAccessor httpContextAccessor)
         : IRequestHandler<GetCartQuery, DataResult<GetCartQueryResult>>
    {
        public async Task<DataResult<GetCartQueryResult>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            var sessionItems = new SessionCartStore(httpContextAccessor).Get();
            if (!sessionItems.Any())
            {
                return DataResult<GetCartQueryResult>.Success(new GetCartQueryResult(), "Sepet boş");
            }

            var products = await productRepository.GetAllAsync();
            var cartItems = sessionItems
                .Join(products.Where(x => x.IsActive),
                    s => s.ProductId,
                    p => p.Id,
                    (s, p) => new CartItemDto
                    {
                        ProductId = p.Id,
                        ProductName = p.Name,
                        ProductImageUrl = p.ImageUrl,
                        Quantity = s.Quantity,
                        UnitPrice = p.Price
                    })
                .ToList();

            return DataResult<GetCartQueryResult>.Success(new GetCartQueryResult
            {
                Items = cartItems
            });
        }
    }
}
