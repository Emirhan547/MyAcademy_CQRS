using MyAcademyCQRS.Core.Application.Features.Commands.CategoryCommands;
using MyAcademyCQRS.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly AppDbContext _appDbContext;

        public UpdateCategoryCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var category = new Category
            {
                Id = command.Id,
                Name = command.Name
            };
            _appDbContext.Categories.Update(category);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
