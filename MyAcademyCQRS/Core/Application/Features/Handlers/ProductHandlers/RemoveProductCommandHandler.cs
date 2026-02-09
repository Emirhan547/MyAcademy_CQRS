using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(AppDbContext _appDbContext)
    {
        public async Task Handle(RemoveProductCommand command)
        {
            var product = await _appDbContext.Products.FindAsync(command.Id);
            _appDbContext.Remove(product);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
