using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyAcademy_CQRS.Application.Contracts.Abstractions;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademy_CQRS.Persistence.Context;
using MyAcademy_CQRS.Persistence.Persistence.Concrete;

namespace MyAcademy_CQRS.Persistence.Concrete
{
    public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
    {
        public async Task<IApplicationTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction = await appDbContext.Database.BeginTransactionAsync(cancellationToken);
            return new EfCoreApplicationTransaction(transaction);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await appDbContext.SaveChangesAsync() > 0;
        }
    }
}
