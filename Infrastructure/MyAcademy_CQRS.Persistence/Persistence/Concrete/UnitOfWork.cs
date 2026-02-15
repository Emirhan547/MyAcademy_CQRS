using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MyAcademy_CQRS.Application.Contracts.Abstractions;
using MyAcademy_CQRS.Application.Contracts.UOW;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete
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
