using Microsoft.EntityFrameworkCore;
using MyAcademy_CQRS.Application.Contracts.Repositories;
using MyAcademyCQRS.Core.Domain.Entities;
using MyAcademyCQRS.Infrastructure.Persistence.Context;

namespace MyAcademyCQRS.Infrastructure.Persistence.Concrete
{
    public class GenericRepository<TEntity>(AppDbContext _appDbContext) : IRepository<TEntity> where TEntity : BaseEntity
    {
        public async Task CreateAsync(TEntity entity)
        {
            await _appDbContext.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _appDbContext.Remove(entity);
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _appDbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _appDbContext.Update(entity);
        }
    }
}
