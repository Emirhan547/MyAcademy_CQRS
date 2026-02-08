using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.Entities;

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
