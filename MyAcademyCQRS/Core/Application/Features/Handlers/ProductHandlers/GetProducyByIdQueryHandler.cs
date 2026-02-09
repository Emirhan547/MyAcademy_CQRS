using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Queries.ProductQueries;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class GetProducyByIdQueryHandler(AppDbContext appDbContext,IMapper mapper)
    {
        public async Task<GetProductByIdQueryResult>Handle(GetProductByIdQuery query)
        {
            var product = await appDbContext.Products.FindAsync(query.Id);
            return mapper.Map<GetProductByIdQueryResult>(product);
        }
    }
}
