using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly AppDbContext _appDbContext;

        public RemoveCategoryCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var category=await _appDbContext.Categories.FindAsync(command.Id);
            _appDbContext.Remove(category);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
