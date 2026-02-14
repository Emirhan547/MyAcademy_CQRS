using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademyCQRS.Core.Application.Contracts
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task <IList<TEntity>>GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
