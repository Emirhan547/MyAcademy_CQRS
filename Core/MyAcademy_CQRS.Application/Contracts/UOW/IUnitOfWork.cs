using Microsoft.EntityFrameworkCore.Storage;

namespace MyAcademy_CQRS.Application.Contracts.UOW
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
