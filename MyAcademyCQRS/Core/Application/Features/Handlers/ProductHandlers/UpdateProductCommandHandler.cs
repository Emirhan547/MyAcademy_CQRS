

using AutoMapper;
using MyAcademyCQRS.Core.Application.Features.Commands.ProductCommands;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Core.Application.Features.Handlers.ProductHandlers
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
