using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IntelligentInvestor.Application.Repositorys.Abstractions;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    #region Entity Set

    EntityEntry<TEntity> Entity(TEntity entity);

    DbSet<TEntity> Set();
    #endregion

    #region Add

    Task<TEntity> AddAsync(TEntity entity);

    TEntity Add(TEntity entity);

    Task<int> AddRangeAsync(IEnumerable<TEntity> entities);

    int AddRange(IEnumerable<TEntity> entities);
    #endregion

    #region Update

    Task<TEntity> UpdateAsync(TEntity entity);

    TEntity Update(TEntity entity);

    Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities);

    int UpdateRange(IEnumerable<TEntity> entities);
    #endregion

    #region Delete

    Task<TEntity> RemoveAsync(TEntity entity);

    TEntity Remove(TEntity entity);

    Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities);

    int RemoveRange(IEnumerable<TEntity> entities);
    #endregion
}
