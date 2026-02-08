using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class GetProductQueryHandler(AppDbContext _appDbContext,IMapper _mapper)
    {
        public async Task<List<GetProductsQueryResult>>Handle()
        {
            var products=await _appDbContext.Products.Include(x=>x.Category).ToListAsync();
            return _mapper.Map<List<GetProductsQueryResult>>(products);
        }
    }
}
