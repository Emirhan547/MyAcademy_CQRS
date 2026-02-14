using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyAcademyCQRS.Core.Application.Contracts;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete
{
    public class UnitOfWork(AppDbContext _appDbContext):IUnitOfWork
    {
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _appDbContext.Database.BeginTransactionAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync() > 0;
        }
    }
}
