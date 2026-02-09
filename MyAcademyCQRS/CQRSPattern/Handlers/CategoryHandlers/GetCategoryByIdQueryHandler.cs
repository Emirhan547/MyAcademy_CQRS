using MyAcademyCQRS.CQRSPattern.Queries.CategoryQueries;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly AppDbContext _appDbContext;

        public GetCategoryByIdQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var category = await _appDbContext.Categories.FindAsync(query.Id);

            return new GetCategoryByIdQueryResult
            {
                Id = category.Id,
                Name = category.Name
            };
        }
    }
}
