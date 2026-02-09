

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Features.Results.ProductResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
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
