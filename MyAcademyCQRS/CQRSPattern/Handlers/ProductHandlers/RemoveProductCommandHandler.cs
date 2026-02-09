using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
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
