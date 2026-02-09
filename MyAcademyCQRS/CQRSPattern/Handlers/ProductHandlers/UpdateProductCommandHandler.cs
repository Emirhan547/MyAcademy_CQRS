using AutoMapper;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(AppDbContext _appDbContext,IMapper _mapper)
    {
        public async Task Handle(UpdateProductCommand command)
        {
            var product = _mapper.Map<Product>(command);
            _appDbContext.Update(product);
            await _appDbContext.SaveChangesAsync();

        }
    }
}
