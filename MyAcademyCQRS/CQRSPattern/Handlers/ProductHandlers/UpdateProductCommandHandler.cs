using AutoMapper;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;

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
