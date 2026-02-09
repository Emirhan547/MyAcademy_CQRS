using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete
{
    public class UnitOfWork(AppDbContext _appDbContext):IUnitOfWork
    {
        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
