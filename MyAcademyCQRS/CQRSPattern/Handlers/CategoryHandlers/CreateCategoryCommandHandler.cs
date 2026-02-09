using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly AppDbContext _appDbContext;

        public CreateCategoryCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            var category = new Category { Name = command.Name };
            await _appDbContext.AddAsync(category);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
