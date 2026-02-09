

using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Features.Results.CategoryResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class GetCategoriesQueryHandler
    {
        private readonly AppDbContext _appDbContext;

        public GetCategoriesQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<GetCategoriesQueryResult>>Handle()
        {
            var categories=await _appDbContext.Categories.ToListAsync();
            return categories.Select(c=>new GetCategoriesQueryResult
                {
                Id=c.Id,
                Name=c.Name,
                 }).ToList();

            }
        }
    }

