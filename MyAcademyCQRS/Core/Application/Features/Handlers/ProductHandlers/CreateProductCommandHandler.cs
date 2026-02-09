

using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
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
