using Microsoft.EntityFrameworkCore.Storage;
using MyAcademy_CQRS.Application.Contracts.Abstractions;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete;

public sealed class EfCoreApplicationTransaction(IDbContextTransaction transaction) : IApplicationTransaction
{
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await transaction.CommitAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await transaction.RollbackAsync(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        await transaction.DisposeAsync();
    }
}