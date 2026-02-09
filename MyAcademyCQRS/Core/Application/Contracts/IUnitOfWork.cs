namespace MyAcademyCQRS.Core.Application.Contracts
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}
