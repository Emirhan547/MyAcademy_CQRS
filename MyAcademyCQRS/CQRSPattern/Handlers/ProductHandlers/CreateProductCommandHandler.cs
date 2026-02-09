using AutoMapper;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(AppDbContext _appDbContext ,IMapper _mapper  ) 
    {
        public async Task Handle(CreateProductCommand command)
        {
            var products = _mapper.Map<Product>(command);
           await  _appDbContext.AddAsync(products);
            await _appDbContext.SaveChangesAsync(); 
        }
    }
}
