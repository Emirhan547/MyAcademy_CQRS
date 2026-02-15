using MyAcademy_CQRS.Application.Contracts.Abstractions;

namespace MyAcademy_CQRS.Application.Contracts.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        Task<IApplicationTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    }
}
