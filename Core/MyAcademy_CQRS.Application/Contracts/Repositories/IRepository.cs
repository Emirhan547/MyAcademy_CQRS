using MyAcademyCQRS.Core.Domain.Entities;

namespace MyAcademy_CQRS.Application.Contracts.Repositories
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
