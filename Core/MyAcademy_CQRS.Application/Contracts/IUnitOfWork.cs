using Microsoft.EntityFrameworkCore.Storage;

namespace MyAcademyCQRS.Core.Application.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
