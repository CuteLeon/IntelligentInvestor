using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace IntelligentInvestor.Application.Repositorys.Abstractions;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
    where TEntity : class
{
    protected readonly ILogger<RepositoryBase<TEntity>> logger;

    public RepositoryBase(
        ILogger<RepositoryBase<TEntity>> logger,
        DbContext DbContext)
    {
        this.logger = logger;
        this.DbContext = DbContext;
        this.logger.LogDebug($"Create data service: {this.GetType().FullName} ({this.GetHashCode():X})");
    }

    #region Database Context

    public DbContext DbContext { get; init; }

    public DatabaseFacade Database => this.DbContext.Database;
    #endregion

    #region Entity Set

    public EntityEntry<TEntity> Entity(TEntity entity)
    {
        return this.DbContext.Entry(entity);
    }

    public DbSet<TEntity> Set()
    {
        return this.DbContext.Set<TEntity>();
    }
    #endregion

    #region Add

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        var result = await this.DbContext.Set<TEntity>().AddAsync(entity);
        _ = await this.DbContext.SaveChangesAsync();
        return result.Entity;
    }

    public virtual TEntity Add(TEntity entity)
    {
        var result = this.DbContext.Set<TEntity>().Add(entity);
        _ = this.DbContext.SaveChanges();
        return result.Entity;
    }

    public virtual async Task<int> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await this.DbContext.Set<TEntity>().AddRangeAsync(entities);
        var result = await this.DbContext.SaveChangesAsync();
        return result;
    }

    public virtual int AddRange(IEnumerable<TEntity> entities)
    {
        this.DbContext.Set<TEntity>().AddRange(entities);
        var result = this.DbContext.SaveChanges();
        return result;
    }
    #endregion

    #region Update

    public virtual async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var result = this.DbContext.Set<TEntity>().Update(entity);
        _ = await this.DbContext.SaveChangesAsync();
        return result.Entity;
    }

    public virtual TEntity Update(TEntity entity)
    {
        var result = this.DbContext.Set<TEntity>().Update(entity);
        _ = this.DbContext.SaveChanges();
        return result.Entity;
    }

    public virtual async Task<int> UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        this.DbContext.Set<TEntity>().UpdateRange(entities);
        var results = await this.DbContext.SaveChangesAsync();
        return results;
    }

    public virtual int UpdateRange(IEnumerable<TEntity> entities)
    {
        this.DbContext.Set<TEntity>().UpdateRange(entities);
        var results = this.DbContext.SaveChanges();
        return results;
    }
    #endregion

    #region Delete

    public virtual async Task<TEntity> RemoveAsync(TEntity entity)
    {
        var result = this.DbContext.Set<TEntity>().Remove(entity);
        _ = await this.DbContext.SaveChangesAsync();
        return result.Entity;
    }

    public virtual TEntity Remove(TEntity entity)
    {
        var result = this.DbContext.Set<TEntity>().Remove(entity);
        _ = this.DbContext.SaveChanges();
        return result.Entity;
    }

    public virtual async Task<int> RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        this.DbContext.Set<TEntity>().RemoveRange(entities);
        var results = await this.DbContext.SaveChangesAsync();
        return results;
    }

    public virtual int RemoveRange(IEnumerable<TEntity> entities)
    {
        this.DbContext.Set<TEntity>().RemoveRange(entities);
        var results = this.DbContext.SaveChanges();
        return results;
    }
    #endregion
}