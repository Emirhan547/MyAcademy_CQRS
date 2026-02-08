using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.ProductQueries;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
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
